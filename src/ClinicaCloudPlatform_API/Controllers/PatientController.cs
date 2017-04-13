using ClinicaCloudPlatform.DAL.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using ClinicaCloudPlatform.Model.ApiModels;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        [HttpGet("{orgNameKey}/{PatientId}")]
        public dynamic Get(string OrgNameKey, int PatientId)
        {
            foreach (dynamic patient in Get(OrgNameKey))
            {
                if (patient.Id == PatientId)
                    return patient;
            }
            return null;
        }

        [HttpGet("{orgNameKey}")]
        public dynamic Get(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new DAL.Data.Functions.PostgreSQL(context);
                return pgHelper.GetPatientsByOrganization(OrgNameKey).Select(p => new
                {
                    Id = p.Id,
                    LastName = p.LastName,
                    FirstName = p.FirstName,
                    MiddleName = p.MiddleName,
                    FullName = string.Format("{0} {1} {2}", p.FirstName, p.MiddleName, p.LastName),
                    DOB = p.DOB,
                    SSN = p.SSN,
                    CustomData = JObject.Parse(p.CustomData ?? "{}")
                });
            }
        }

        [HttpGet("[action]/{orgNameKey}/{query}")]
        public dynamic Search(string OrgNameKey, string query)
        {
            query = query ?? string.Empty;

            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new DAL.Data.Functions.PostgreSQL(context);
                dynamic patients = pgHelper.GetPatientsByOrganization(OrgNameKey).Select(p => new
                {
                    Id = p.Id,
                    LastName = p.LastName,
                    FirstName = p.FirstName,
                    DOB = p.DOB,
                    SSN = p.SSN,
                    CustomData = JObject.Parse(p.CustomData ?? "{}")
                });

                //filter via json
                JArray result = JArray.FromObject(patients);

                var jPatientsToRemove = new List<JToken>();

                foreach (JToken jPatient in result)
                {
                    bool match = false;
                    foreach (var jProp in jPatient.Children<JProperty>())
                        if (jProp.Value.ToString().ToLower().Contains(query.ToLower()))
                            match = true;
                    if (!match)
                        jPatientsToRemove.Add(jPatient);
                }

                jPatientsToRemove.ForEach(t => t.Remove());

                return (dynamic)result;
            }
        }

        [HttpPost("")]
        public SaveResponseGeneric Save([FromBody]dynamic PatientState)
        {
            Patient patient;
            var pJson = ((JObject)PatientState);
            try { patient = JsonConvert.DeserializeObject<Patient>(pJson.GetValue("patient").ToString()); }
            catch (Exception ex) { throw new FormatException("Error casting request body as Patient, did JSON change?", ex); }

            var userFullName = PatientState.userFullName.ToString();
            var userHref = PatientState.userHref.ToString();

            using (var context = new ArsMachinaLIMSContext(userFullName, userHref))
            {
                var dbPatient = context.Find<Model.Models.Patient>(patient.Id);
                if (dbPatient == null)
                {
                    dbPatient = new Model.Models.Patient();
                    dbPatient.CreatedFullName = userFullName;
                    dbPatient.CreatedHref = userHref;
                    context.Patients.Add(dbPatient);
                }

                dbPatient.LastName = patient.LastName;
                dbPatient.MiddleName = patient.MiddleName;
                dbPatient.FirstName = patient.FirstName;
                dbPatient.SSN = patient.SSN;
                dbPatient.DOB = patient.DOB;
                dbPatient.CustomData = patient.CustomData.ToString();

                context.SaveChanges();
                
                return new SaveResponseGeneric() { Guid = dbPatient.Guid, Id = dbPatient.Id };
            }
        }
    }
}
