using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Batch : _LimsBaseClass
    {
        public string BatchNumber { get; set; }
        public string BatchStatus { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
        public ICollection<Specimen> Specimens { get; set; }

        /*******
            JSON data to include extended attributes for batch according to type
        *******/
    }
}
