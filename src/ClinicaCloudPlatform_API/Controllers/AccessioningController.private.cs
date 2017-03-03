using ClinicaCloudPlatform.DAL.Data;
using ClinicaCloudPlatform.Model.ApiModels;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace ClinicaCloudPlatform.API.Controllers
{
    public partial class AccessioningController
    {
        

        private static void ProcessSpecimens(string UserFullName, string UserHref, Accession accession,
            ArsMachinaLIMSContext context, Model.Models.Accession dbAcc)
        {
            foreach (var specimen in accession.Specimens)
            {
                var dbSpec = context.Find<Model.Models.Specimen>(specimen.Id);
                if (dbSpec == null)
                {
                    dbSpec = new Model.Models.Specimen();
                    dbSpec.CreatedFullName = UserFullName;
                    dbSpec.CreatedHref = UserHref;
                    dbAcc.Specimens.Add(dbSpec);
                }

                /* hopefully EF will do this
                dbSpec.Category = (string)ChangeDetection.GetChangedValue(specimen.Category, dbSpec.Category, ref changed);
                dbSpec.Code = (string)ChangeDetection.GetChangedValue(specimen.Code, dbSpec.Code, ref changed);
                dbSpec.CollectionDate = (DateTime)ChangeDetection.GetChangedValue(specimen.CollectionDate, dbSpec.CollectionDate, ref changed);
                dbSpec.CustomData = (string)ChangeDetection.GetChangedValue(specimen.CustomData, dbSpec.CustomData, ref changed);
                dbSpec.ExternalSpecimenId = (string)ChangeDetection.GetChangedValue(specimen.ExternalSpecimenId, dbSpec.ExternalSpecimenId, ref changed);
                dbSpec.ParentSpecimenId = (int)ChangeDetection.GetChangedValue(specimen.ParentSpecimenId, dbSpec.ParentSpecimenId, ref changed);
                dbSpec.ReceivedDate = (DateTime)ChangeDetection.GetChangedValue(specimen.ReceivedDate, dbSpec.ReceivedDate, ref changed);
                dbSpec.Transport = (string)ChangeDetection.GetChangedValue(specimen.Transport, dbSpec.Transport, ref changed);
                dbSpec.Type = (string)ChangeDetection.GetChangedValue(specimen.Type, dbSpec.Type, ref changed);
                */

                dbSpec.Category = specimen.Category;
                dbSpec.Code = specimen.Code;
                dbSpec.CollectionDate = specimen.CollectionDate;
                dbSpec.CustomData = specimen.CustomData.ToString();
                dbSpec.ExternalSpecimenID = specimen.ExternalSpecimenId;
                dbSpec.ParentSpecimenID = specimen.ParentSpecimenId;
                dbSpec.ReceivedDate = specimen.ReceivedDate;
                dbSpec.Transport = specimen.Transport;
                dbSpec.Type = specimen.Type;

                if (!(context.Entry(dbSpec).State == Microsoft.EntityFrameworkCore.EntityState.Unchanged))
                {
                    dbSpec.ModifiedFullName = UserFullName;
                    dbSpec.ModifiedHref = UserHref;
                }
            }
        }

        private static void ProcessCases(string UserFullName, string UserHref, Accession accession, dynamic orgCustomData, ArsMachinaLIMSContext context, Model.Models.Accession dbAcc)
        {
            foreach (Case _case in accession.Cases)
            {
                var dbCase = context.Cases
                    .Include(c => c.Specimens)
                    .Include(c => c.ProcessingLab)
                    .Include(c => c.ProfessionalLab)
                    .Include(c => c.AnalysisLab)
                    .Include(c => c.PanelResults)
                    .Include(c => c.TestResults)
                    .FirstOrDefault(c => c.Id == _case.Id);

                //get custom case type definition from organization custom data (stormpath json)
                IEnumerable<dynamic> caseTypeDefinitions = orgCustomData?.caseTypeDefinitions;
                if (caseTypeDefinitions == null)
                    throw new FormatException("No Case Type definitions supplied.  Check Organization Custom Data.");

                dynamic caseTypeDefinition;

                if (caseTypeDefinitions.Any(d => d.caseTypeName == _case.Type))
                    caseTypeDefinition = caseTypeDefinitions.First(c => c.caseTypeName == _case.Type);
                else
                    caseTypeDefinition = caseTypeDefinitions.FirstOrDefault(d => d.defaultCaseType);

                if (caseTypeDefinition == null)
                    throw new FormatException("No Case Type definition '" + _case.Type + "' or default case type configured.  Check Organization Custom Data.");

                //handle new cases
                if (dbCase == null)
                {
                    dbCase = new Model.Models.Case();
                    dbCase.CreatedFullName = UserFullName;
                    dbCase.CreatedHref = UserHref;
                    try
                    {
                        //set case number per case type definition
                        dbCase.CaseNumber = DAL.Data.Functions.Sequencing.GetFormattedSequence<Model.Models.Case>(
                            caseTypeDefinition.caseNumberprefix,
                            int.Parse(caseTypeDefinition.caseNumberMinLength),
                            caseTypeDefinition.caseNumberDelimiter,
                            Boolean.Parse(caseTypeDefinition.caseNumberIncludeDatePart),
                            caseTypeDefinition.caseNumberDotNetDateFormat
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException("CaseNumber Generation: Error processing specified Case Type definition.", ex);
                    }

                    //TODO workflow

                    dbAcc.Cases.Add(dbCase);
                }
                else
                    dbCase.CaseNumber = _case.CaseNumber;

                dbCase.AnalysisLab = context.Find<Model.Models.Lab>(_case.AnalysisLabId);
                dbCase.CustomData = _case.CustomData;

                if (dbCase.PanelResults == null)
                    dbCase.PanelResults = new List<Model.Models.PanelResult>();
                foreach (var presult in _case.PanelResults)
                {
                    var existingResult = dbCase.PanelResults.FirstOrDefault(pr => pr.Guid == presult.Guid);
                    if (existingResult == null)
                    {
                        existingResult = new Model.Models.PanelResult();
                        dbCase.PanelResults.Add(existingResult);
                        existingResult.Guid = presult.Guid;
                    }
                    existingResult.PanelCode = presult.PanelCode;
                    existingResult.PanelName = presult.PanelName;
                    existingResult.CustomData = presult.CustomData.ToString();
                }

                dbCase.ProcessingLab = context.Find<Model.Models.Lab>(_case.ProcessingLabId);
                dbCase.ProfessionalLab = context.Find<Model.Models.Lab>(_case.ProfessionalLabId);

                dbCase.Specimens = new List<Model.Models.Specimen>();
                foreach (var dbSpec in dbAcc.Specimens.Where(s => _case.SpecimenGuids.Contains(s.Guid)))
                    dbCase.Specimens.Add(dbSpec);

                if (dbCase.TestResults == null)
                    dbCase.TestResults = new List<Model.Models.TestResult>();
                foreach (var tresult in _case.TestResults)
                {
                    var existingResult = dbCase.TestResults.FirstOrDefault(pr => pr.Guid == tresult.Guid);
                    if (existingResult == null)
                    {
                        existingResult = new Model.Models.TestResult();
                        dbCase.TestResults.Add(existingResult);
                        existingResult.Guid = tresult.Guid;
                    }
                    existingResult.TestCode = tresult.TestCode;
                    existingResult.TestName = tresult.TestName;
                    existingResult.CustomData = tresult.CustomData.ToString();
                }

                dbCase.Type = _case.Type;

                if (context.ChangeTracker.Entries<Model.Models.Case>().Any(c =>
                 c.State == Microsoft.EntityFrameworkCore.EntityState.Modified ||
                 c.State == Microsoft.EntityFrameworkCore.EntityState.Added))
                {
                    dbCase.ModifiedFullName = UserFullName;
                    dbCase.ModifiedHref = UserHref;
                }

            }
        }

        private static SaveResponseAccession GenerateSaveAccessionResponse(Accession accession, Model.Models.Accession dbAcc)
        {
            var response = new SaveResponseAccession();
            response.Guid = dbAcc.Guid;
            response.Id = dbAcc.Id;

            response.SpecimensInfo = new List<SaveResponseGeneric>();
            response.CasesInfo = new List<SaveResponseCase>();

            foreach (var dbSpec in dbAcc.Specimens)
            {
                response.SpecimensInfo.Add(new SaveResponseGeneric() { Id = dbSpec.Id, Guid = dbSpec.Guid });
            }

            foreach (var dbCase in dbAcc.Cases)
            {
                var _case = accession.Cases.Single(c => c.Guid == dbCase.Guid);
                var responseCaseInfo = new SaveResponseCase();
                responseCaseInfo.Guid = dbAcc.Guid;
                responseCaseInfo.Id = dbAcc.Id;
                responseCaseInfo.PanelResultsInfo = _case.PanelResults.Select(p => new SaveResponseGeneric() { Id = p.Id, Guid = p.Guid });
                responseCaseInfo.TestResultsInfo = _case.TestResults.Select(p => new SaveResponseGeneric() { Id = p.Id, Guid = p.Guid });
                responseCaseInfo.SpecimensInfo = response.SpecimensInfo.Where(s => _case.SpecimenGuids.Contains(s.Guid));
                response.CasesInfo.Add(responseCaseInfo);
            }

            return response;
        }
    }
}
