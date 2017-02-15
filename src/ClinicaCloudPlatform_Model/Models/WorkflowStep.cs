namespace ClinicaCloudPlatform.Model.Models
{
    public class WorkflowStep : _LimsBaseClass
    {
        public Workflow Workflow { get; set; }
        public Step Step { get; set; }
        public int StepOrder { get; set; }
    }
}
