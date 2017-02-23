using System;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Specimen : _LimsBaseClass
    {
        public int ParentSpecimenID { get; set; }
        public string ExternalSpecimenID { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Transport { get; set; }
        public string Category { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        /*
         * JSON contains specimen data fields 
         */
    }
}
