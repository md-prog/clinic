using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Client : _ApiModelBaseClass
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
    }

}
