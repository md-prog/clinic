using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Client : _LimsBaseClass
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}
