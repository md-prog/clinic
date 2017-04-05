using ClinicaCloudPlatform.DAL.Data;
using ClinicaCloudPlatform.Model.ApiModels;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace ClinicaCloudPlatform.API.Controllers
{
    public partial class AccessioningController
    {
        private static IEnumerable<SaveResponseSpecimen> ProcessSpecimens(string OrgNameKey, string UserFullName, string UserHref, Accession accession,
            ArsMachinaLIMSContext context, Model.Models.Accession dbAcc)
        {
            var responses = new List<SaveResponseSpecimen>();

            dbAcc.Specimens = new List<Model.Models.Specimen>();

            foreach (var specimen in accession.Specimens)
            {
                var response = new SaveResponseSpecimen();
                response.Guid = specimen.Guid;

                bool newSpecimen = false;
                var dbSpec = context.Find<Model.Models.Specimen>(specimen.Id);
                if (dbSpec == null)
                {
                    dbSpec = new Model.Models.Specimen();
                    dbSpec.CreatedFullName = UserFullName;
                    dbSpec.CreatedHref = UserHref;
                    dbAcc.Specimens.Add(dbSpec);
                    newSpecimen = true;
                }

                dbSpec.Category = specimen.Category;
                dbSpec.Code = specimen.Code;
                dbSpec.CollectionDate = specimen.CollectionDate;
                dbSpec.CustomData = specimen.CustomData.ToString();
                dbSpec.ExternalSpecimenID = specimen.ExternalSpecimenId;
                dbSpec.ParentSpecimenGuid = specimen.ParentSpecimenGuid;
                dbSpec.ReceivedDate = specimen.ReceivedDate;
                dbSpec.Transport = specimen.Transport.Name;
                dbSpec.TransportCode = specimen.Transport.Code;
                dbSpec.Type = specimen.Type.Type;
                dbSpec.TypeCode = specimen.Type.Code;

                if (context.Entry(dbSpec).State != Microsoft.EntityFrameworkCore.EntityState.Unchanged)
                {
                    dbSpec.ModifiedFullName = UserFullName;
                    dbSpec.ModifiedHref = UserHref;
                }

                //process barcodes for specimens only, for now
                var barcodeRequest = new SaveRequestBarcode()
                {
                    AccessionGuid = accession.Guid,
                    NewBarcode = newSpecimen,
                    Number = specimen.BarcodeNumber,
                    OrgNameKey = OrgNameKey,
                    SpecimenGuid = specimen.Guid,
                    userFullName = UserFullName,
                    userHref = UserHref
                };
                response.BarcodeNumber = new BarcodeController().SaveBarcode(JObject.FromObject(barcodeRequest));

                responses.Add(response);
            }
            return responses;
        }

        private static IEnumerable<SaveResponseCase> ProcessCases(string UserFullName, string UserHref, Accession accession, dynamic orgCustomData, ArsMachinaLIMSContext context, Model.Models.Accession dbAcc)
        {
            dbAcc.Cases = new List<Model.Models.Case>();

            var responses = new List<SaveResponseCase>();

            foreach (Case _case in accession.Cases)
            {
                var response = new SaveResponseCase();
                response.Guid = _case.Guid;

                //since db save is at accession level, might as well just leave these at that level for now (generate save response method)
                //response.PanelResultsInfo = new List<SaveResponseGeneric>();
                //response.SpecimensInfo = new List<SaveResponseSpecimen>();
                //response.TestResultsInfo = new List<SaveResponseGeneric>();

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

                response.CaseNumber = dbCase.CaseNumber;

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
                responses.Add(response);
            }
            return responses;
        }

        private static SaveResponseAccession GenerateSaveAccessionResponse(Accession accession, 
            IEnumerable<SaveResponseSpecimen> specimenResponses, IEnumerable<SaveResponseCase> caseResponses, 
            Model.Models.Accession dbAcc)
        {
            var response = new SaveResponseAccession();
            response.Guid = dbAcc.Guid;
            response.Id = dbAcc.Id;

            response.SpecimensInfo = new List<SaveResponseSpecimen>();
            response.CasesInfo = new List<SaveResponseCase>();

            foreach(var specResponse in specimenResponses)
            {
                specResponse.Id = dbAcc.Specimens.SingleOrDefault(s => s.Guid == specResponse.Guid)?.Id ?? -1;
                response.SpecimensInfo.Add(specResponse);
            }
            foreach (var caseResponse in caseResponses)
            {
                var _case = accession.Cases.Single(c => c.Guid == caseResponse.Guid);
                caseResponse.Id = dbAcc.Id;
                caseResponse.PanelResultsInfo = _case.PanelResults.Select(p => new SaveResponseGeneric() { Id = p.Id, Guid = p.Guid });
                caseResponse.TestResultsInfo = _case.TestResults.Select(p => new SaveResponseGeneric() { Id = p.Id, Guid = p.Guid });
                caseResponse.SpecimensInfo = response.SpecimensInfo.Where(s => _case.SpecimenGuids.Contains(s.Guid));
                response.CasesInfo.Add(caseResponse);
            }

            return response;
        }
    }
}
