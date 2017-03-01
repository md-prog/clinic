using ClinicaCloudPlatform.DAL.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
                    DOB = p.DOB,
                    SSN = p.SSN
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
                    SSN = p.SSN
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
    }
}
