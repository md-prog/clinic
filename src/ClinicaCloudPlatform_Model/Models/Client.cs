using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Client : _LimsBaseClass
    {
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }

}
