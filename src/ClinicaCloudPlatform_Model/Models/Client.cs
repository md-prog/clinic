using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Client : _LimsBaseClass
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }

}
