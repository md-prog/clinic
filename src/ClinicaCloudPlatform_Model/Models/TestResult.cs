namespace ClinicaCloudPlatform.Model.Models
{
    public class TestResult : _LimsBaseClass
    {
        public Test Test { get; set; }
        public Panel Panel { get; set; }
        /*
         * JSON includes all default test result fields, mappings, etc
         */
    }
}
