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
                var pgHelper = new Controller_Helpers.pgSqlJson(context);

                retVal = context.Accessions.Where(a => a.ID == ID).Select(acc => new
                {
                    ID = acc.ID,
                    Clients = pgHelper.GetClientsByOrganization(OrgNameKey).Select(c => new
                    {
                        ID = c.ID,
                        Name = c.ClientName
                    }),
                    Client = new
                    {
                        ID = acc.Client.ID,
                        Name = acc.Client.ClientName
                    },
                    Facilities = acc.Client.Facilities.Select(f => new { f.ID, f.Name }), //rebind on client change...
                    Facility = new
                    {
                        ID = acc.Facility.ID,
                        Name = acc.Facility.Name
                    },
                    Patients = pgHelper.GetPatientsByOrganization(OrgNameKey).Select(p => new
                    {
                        ID = p.ID,
                        LastName = p.LastName,
                        FirstName = p.FirstName,
                        DOB = p.DOB,
                        SSN = p.SSN
                    }),
                    Patient = new
                    {
                        ID = acc.Patient.ID,
                        LastName = acc.Patient.LastName,
                        FirstName = acc.Patient.FirstName,
                        DOB = acc.Patient.DOB,
                        SSN = acc.Patient.SSN
                    },
                    MRN = acc.MRN,
                    Specimens = acc.Specimens.Select(s => new
                    {
                        ID = s.ID,
                        ExternalID = s.ExternalSpecimenID,
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

    }
}
