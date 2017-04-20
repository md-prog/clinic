using System;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Barcode : _LimsBaseClass
    {
        public string Number { get; set; }
        public Guid AccessionGuid { get; set; }
    }
}
