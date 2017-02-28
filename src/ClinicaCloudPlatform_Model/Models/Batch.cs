using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Batch : _LimsBaseClass, ITypeSequenced
    {
        public string BatchNumber { get; set; }
        public string BatchStatus { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
        public ICollection<Specimen> Specimens { get; set; }
        public string Type { get; set; }
        public int CurrentTypeSequenceNumber { get; set; }
        /*******
            JSON data to include extended attributes for batch according to type
        *******/
    }
}
