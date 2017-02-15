using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class CaseType : _LimsBaseClass
    {
        public string CaseTypeName { get; set; }
        public string CaseNumberPrefix { get; set; }
        public ICollection<TestType> TestTypes { get; set; }
        /*
        * JSON contains default fields to be included with Case
        */
    }
}
