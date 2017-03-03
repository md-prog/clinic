using Microsoft.AspNetCore.Mvc;
using ClinicaCloudPlatform.DAL.Data;
using System.Linq;
using ClinicaCloudPlatform.Model.ApiModels;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClinicaCloudPlatform.API.Controllers
{
    /// <summary>
    /// This controller is being exposed via GUI project
    /// See comments in GUI/Startup.cs
    /// </summary>
    [Route("api/[controller]")]
    public partial class AccessioningController : Controller
    {
        [HttpGet("{orgNameKey}")]
        public dynamic Get(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                //EF at its crappiest
                return context.Accessions
                    .Include(a => a.Client)
                    .ThenInclude(c => c.Facilities)
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor1)
                    .Include(a => a.Doctor2)
                    .Include(a => a.Facility)
                    .Include(a => a.OrderingLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.Specimens)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.PanelResults)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.TestResults)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.ProcessingLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.ProfessionalLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.AnalysisLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.Specimens)
                    .Include(a => a.Specimens)
                    .Select(a => Mapping.Accession.GetAccessionApiModel(a, new Mapping.AccessionMapOptions()
                    {
                        IncludeCases = true,
                        IncludeSpecimens = true
                    })).ToList();
                //return accessions.Select(a => GetAccessionApiModel(a));
            }
        }

        [HttpGet("{Id}/{orgNameKey}")]
        public dynamic Get(int Id, string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                //EF at its crappiest
                var DbAcc = context.Accessions
                    .Include(a => a.Client)
                    .ThenInclude(c => c.Facilities)
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor1)
                    .Include(a => a.Doctor2)
                    .Include(a => a.Facility)
                    .Include(a => a.OrderingLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.Specimens)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.PanelResults)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.TestResults)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.ProcessingLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.ProfessionalLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.AnalysisLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.Specimens)
                    .Include(a => a.Specimens)
                    .First(a => a.Id == Id);

                Accession accession = Mapping.Accession.GetAccessionApiModel(DbAcc,
                    new Mapping.AccessionMapOptions()
                    {
                        IncludeCases = true,
                        IncludeSpecimens = true
                    });

                var patient = new Patient()
                {
                    Guid = DbAcc.Patient.Guid,
                    Id = DbAcc.Patient.Id,
                    LastName = DbAcc.Patient.LastName,
                    FirstName = DbAcc.Patient.FirstName,
                    DOB = DbAcc.Patient.DOB,
                    SSN = DbAcc.Patient.SSN
                };

                var client = new Client()
                {
                    Guid = DbAcc.Client.Guid,
                    Id = DbAcc.Client.Id,
                    Name = DbAcc.Client.Name,
                    Facilities = DbAcc.Client.Facilities.Select(f => new Facility()
                    {
                        Guid = f.Guid,
                        Id = f.Id,
                        Name = f.Name
                    })
                };

                var facility = new Facility()
                {
                    Guid = DbAcc.Facility.Guid,
                    Id = DbAcc.Facility.Id,
                    Name = DbAcc.Facility.Name
                };

                return new
                {
                    Accession = accession,
                    Patient = patient,
                    Client = client,
                    Facility = facility
                };
            }
        }

        [HttpPost("")]
        public SaveResponseAccession Save([FromBody]dynamic AccessionState) //could get user from identity/stormpath but need to think about api usage and caching
        {
            Accession accession;
            var accJson = ((JObject)AccessionState);
            try { accession = JsonConvert.DeserializeObject<Accession>(accJson.GetValue("accession").ToString()); }
            catch (Exception ex) { throw new FormatException("Error casting request body as Accession, did JSON change?", ex); }

            var userFullName = AccessionState.userFullName.ToString();
            var userHref = AccessionState.userHref.ToString();

            using (var context = new ArsMachinaLIMSContext(userFullName, userHref))
            {
                var dbAcc = context.Find<Model.Models.Accession>(accession.Id);
                if (dbAcc == null)
                {
                    dbAcc = new Model.Models.Accession();
                    dbAcc.CreatedFullName = userFullName;
                    dbAcc.CreatedHref = userHref;
                    context.Accessions.Add(dbAcc);
                }

                //Cases: process after specimens

                //Find<> is potentially faster than lambdas
                dbAcc.Client = context.Find<Model.Models.Client>(accession.ClientId);
                dbAcc.Doctor1 = context.Find<Model.Models.Doctor>(accession.Doctor1Id);
                dbAcc.Doctor2 = context.Find<Model.Models.Doctor>(accession.Doctor2Id);
                dbAcc.Facility = context.Find<Model.Models.Facility>(accession.FacilityId);
                dbAcc.MRN = accession.MRN;
                dbAcc.OrderingLab = context.Find<Model.Models.Lab>(accession.OrderingLabId);
                dbAcc.Patient = context.Find<Model.Models.Patient>(accession.PatientId);

                ProcessSpecimens(userFullName, userHref, accession, context, dbAcc);

                ProcessCases(userFullName, userHref, accession, AccessionState.orgCustomData, context, dbAcc);

                context.SaveChanges();

                //configure response object
                return GenerateSaveAccessionResponse(accession, dbAcc);
            }
        }

    }
}
