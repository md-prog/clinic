using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class TestResult : _ApiModelBaseClass
    {
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public string CustomData { get; set; }
        /*
         * JSON includes all default test result fields, mappings, etc
         */
    }
}
