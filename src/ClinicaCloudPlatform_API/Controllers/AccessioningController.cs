using Microsoft.AspNetCore.Mvc;
using ClinicaCloudPlatform.DAL.Data;
using System.Linq;


namespace ClinicaCloudPlatform.API.Controllers
{
    /// <summary>
    /// This controller is being exposed via ArsMachina
    /// See comments in ArsMachina/Startup.cs
    /// </summary>
    [Route("api/[controller]")]
    public class AccessioningController : Controller
    {
        [HttpGet("[action]/{id}/{orgNameKey}")]
        public dynamic Get(int ID, string OrgNameKey)
        {
            dynamic retVal = null;

            using (var context = new ArsMachinaLIMSContext())
            {

                retVal = context.Accessions.Where(a => a.ID == ID).Select(acc => new
                {
                    ID = acc.ID,
                    Client = new
                    {
                        ID = acc.Client.ID,
                        Name = acc.Client.ClientName,
                        Facilities = acc.Client.Facilities.Select(f => new
                        {
                            ID = f.ID,
                            Name = f.Name
                        })
                    },
                    Facility = new
                    {
                        ID = acc.Facility.ID,
                        Name = acc.Facility.Name
                    },
                    Patient = new
                    {
                        ID = acc.Patient.ID,
                        LastName = acc.Patient.LastName,
                        FirstName = acc.Patient.FirstName,
                        DOB = acc.Patient.DOB,
                        SSN = acc.Patient.SSN
                    },
                    Doctor1 = new
                    {
                        ID = acc.Doctor1.ID,
                        LastName = acc.Doctor1.LastName,
                        FirstName = acc.Doctor1.FirstName
                    },
                    Doctor2 = new
                    {
                        ID = acc.Doctor2.ID,
                        LastName = acc.Doctor2.LastName,
                        FirstName = acc.Doctor2.FirstName
                    },
                    MRN = acc.MRN,
                    Specimens = acc.Specimens.Select(s => new
                    {
                        ID = s.ID,
                        Code = s.Code,
                        ExternalSpecimenID = s.ExternalSpecimenID,
                        Type = s.Type,
                        Transport = s.Transport,
                        CollectionDate = s.CollectionDate,
                        ReceivedDate = s.ReceivedDate,
                        CustomData = s.JsonExtendedData,
                    }),
                    Cases = acc.Cases.Select(c => new
                    {
                        ID = c.ID,
                        CaseNumber = c.CaseNumber,
                        ProcessingLab = c.ProcessingLab.LabName,
                        AnalysisLab = c.AnalysisLab.LabName,
                        ProfessionalLab = c.ProcessingLab.LabName,
                        CustomData = c.JsonExtendedData,
                        Panels = c.PanelResults.Select(p => new
                        {
                            PanelName = p.PanelName,
                            CustomData = p.JsonExtendedData
                        }),
                        Tests = c.TestResults.Select(t => new
                        {
                            TestName = t.TestName,
                            CustomData = t.JsonExtendedData
                        })
                    })
                }).FirstOrDefault();
            }

            return retVal;
        }

        [HttpGet("[action]/{orgNameKey}")]
        public dynamic Clients(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new Controller_Helpers.pgSqlJson(context);
                return pgHelper.GetClientsByOrganization(OrgNameKey).Select(c => new
                {
                    ID = c.ID,
                    Name = c.ClientName,
                    Facilities = c.Facilities.Select(f => new
                    {
                        ID = f.ID,
                        Name = f.Name
                    }
                    )
                });
            }
        }

        [HttpGet("[action]/{orgNameKey}")]
        public dynamic Patients(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new Controller_Helpers.pgSqlJson(context);
                return pgHelper.GetPatientsByOrganization(OrgNameKey).Select(p => new
                {
                    ID = p.ID,
                    LastName = p.LastName,
                    FirstName = p.FirstName,
                    DOB = p.DOB,
                    SSN = p.SSN
                });
            }
        }

        [HttpGet("[action]/{orgNameKey}")]
        public dynamic Doctors(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new Controller_Helpers.pgSqlJson(context);
                return pgHelper.GetDoctorsByOrganization(OrgNameKey).Select(p => new
                {
                    ID = p.ID,
                    LastName = p.LastName,
                    FirstName = p.FirstName
                });
            }
        }
    }
}
