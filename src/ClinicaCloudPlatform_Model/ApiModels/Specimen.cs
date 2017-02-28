using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Specimen : _ApiModelBaseClass
    {
        public int ParentSpecimenId { get; set; }
        public string ExternalSpecimenId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Transport { get; set; }
        public string Category { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public dynamic CustomData { get; set; }
        /*
         * JSON contains specimen data fields 
         */
    }
}
