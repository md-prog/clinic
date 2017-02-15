namespace ClinicaCloudPlatform.Model.Models
{
    public class Panel : _LimsBaseClass
    {
        public string PanelName { get; set; }
        public string PanelCode { get; set; }
        public string PanelDescription { get; set; }
        /*
         * JSON contains default fields to be included with PanelResult
         */
    }

    public class PanelTest : _LimsBaseClass
    {
        public Panel Panel { get; set; }
        public Test Test { get; set; }
        public Test TestOrder { get; set; }
    }
}
