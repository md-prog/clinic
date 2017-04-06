using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Specimen : _ApiModelBaseClass
    {
        public Guid ParentSpecimenGuid { get; set; }
        public string ExternalId { get; set; }
        public string Code { get; set; }
        public SpecimenType Type { get; set; }
        public SpecimenTransport Transport { get; set; }
        public string Category { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string BarcodeNumber { get; set; }
        public dynamic CustomData { get; set; }
        /*
         * JSON contains specimen data fields 
         */
    }

    public class SpecimenType
    {
        public string Type { get; set; } //'type' is already used all over in gui
        public string Code { get; set; }
    }

    public class SpecimenTransport
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
