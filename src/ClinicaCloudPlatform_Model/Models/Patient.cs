using System;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Patient : _LimsBaseClass
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
    }
}
