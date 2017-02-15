namespace ClinicaCloudPlatform.Model.Models
{
    public class Test : _LimsBaseClass
    {
        public string TestName { get; set; }
        public string TestCode { get; set; }
        public TestType TestType { get; set; }

        /*
         * JSON includes all default test result fields, mappings, etc
         */
    }
}
