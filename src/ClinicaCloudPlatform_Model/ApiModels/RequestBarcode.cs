using System;
using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class RequestBarcode
    {
        public string OrgNameKey { get; set; }
        public string Number { get; set; }

        public IEnumerable<Guid> SpecimenGuids { get; set; }

        public Guid AccessionGuid { get; set; }

        public Guid CaseGuid { get; set; }

        public string userHref { get; set; }
        public string userFullName { get; set; }
    }
}
