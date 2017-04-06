using System;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Specimen : _LimsBaseClass
    {
        public Guid ParentSpecimenGuid { get; set; }
        public string ExternalID { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public string Transport { get; set; }
        public string TransportCode { get; set; }
        public string Category { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        /*
         * JSON contains specimen data fields 
         */
    }
}
