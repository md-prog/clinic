using System;
using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class SaveRequestBarcode
    {
        public string OrgNameKey { get; set; }
        public bool NewBarcode { get; set; }
        public string Number { get; set; }

        public IEnumerable<Guid> SpecimenGuids { get; set; }

        public Guid AccessionGuid { get; set; }

        public Guid CaseGuid { get; set; }

        public string userHref { get; set; }
        public string userFullName { get; set; }
    }
}
