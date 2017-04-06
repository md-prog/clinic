using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ClinicaCloudPlatform.API.Mapping
{
    public class AccessionMapOptions
    {
        public bool IncludeCases { get; set; }
        public bool IncludeSpecimens { get; set; }
    }
    public static class Accession
    {
        public static Model.ApiModels.Accession GetAccessionApiModel(Model.Models.Accession DbAcc, AccessionMapOptions Options)
        {
            return new Model.ApiModels.Accession()
            {
                Id = DbAcc.Id,
                Guid = DbAcc.Guid,
                CreatedDate = DbAcc.CreatedDate,
                CreatedFullName = DbAcc.CreatedFullName,
                ClientId = DbAcc.Client.Id,
                FacilityId = DbAcc.Facility.Id,
                PatientId = DbAcc.Patient.Id,
                Doctor1Id = DbAcc.Doctor1?.Id ?? 0,
                Doctor2Id = DbAcc.Doctor2?.Id ?? 0,
                MRN = DbAcc.MRN,
                OrderingLabId = DbAcc.OrderingLab.Id,
                Specimens = !Options.IncludeSpecimens ? null : DbAcc.Specimens.Select(s => new Model.ApiModels.Specimen
                {
                    Id = s.Id,
                    Guid = s.Guid,
                    Code = s.Code,
                    ParentSpecimenGuid = s.ParentSpecimenGuid,
                    ExternalId = s.ExternalID,
                    Type = new Model.ApiModels.SpecimenType() { Type = s.Type, Code = s.TypeCode },
                    Transport = new Model.ApiModels.SpecimenTransport() { Name = s.Transport, Code = s.TransportCode },
                    CollectionDate = s.CollectionDate,
                    ReceivedDate = s.ReceivedDate,                    
                    CustomData = JObject.Parse(s.CustomData ?? "{}"),
                }),
                Cases = !Options.IncludeCases ? null : DbAcc.Cases.Select(c => new Model.ApiModels.Case
                {
                    Id = c.Id,
                    Guid = c.Guid,
                    CaseNumber = c.CaseNumber,
                    ProcessingLabId = c.ProcessingLab?.Id ?? 0,
                    AnalysisLabId = c.AnalysisLab?.Id ?? 0,
                    ProfessionalLabId = c.ProcessingLab?.Id ?? 0,
                    SpecimenGuids = c.Specimens.Select(s => s.Guid),
                    PanelResults = c.PanelResults.Select(p => new Model.ApiModels.PanelResult
                    {
                        PanelName = p.PanelName,
                        CustomData = JObject.Parse(p.CustomData ?? "{}")
                    }),
                    TestResults = c.TestResults.Select(t => new Model.ApiModels.TestResult
                    {
                        TestName = t.TestName,
                        CustomData = JObject.Parse(t.CustomData ?? "{}")
                    })
                })
            };
        }
    }
}
