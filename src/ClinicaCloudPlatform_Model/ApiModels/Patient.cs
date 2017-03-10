using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Patient : _ApiModelBaseClass
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
    }
}
