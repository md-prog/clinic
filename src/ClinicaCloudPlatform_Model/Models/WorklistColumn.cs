namespace ClinicaCloudPlatform.Model.Models
{
    public class WorklistColumn : _LimsBaseClass
    {
        public string WorklistColumnName { get; set; }
        public WorklistColumnDataTypes WorklistColumnDataType { get; set; }
        public WorklistColumnLinkTypes WorklistColumnLinkType { get; set; }
    }
    public enum WorklistColumnDataTypes
    {
        String,
        Date,
        Timestamp,
        Icon,
        Component
    }
    public enum WorklistColumnLinkTypes
    {
        Standard,
        Dashboard,
        PendingReport,
        FinalReport
    }

    /*
     * JSON includes mapping and details link configurations
     */
}
