namespace ClinicaCloudPlatform.Model.Models
{
    public class Workflow : _LimsBaseClass
    {
        public string WorkflowName { get; set; }
        public WorkflowTypes WorkflowType { get; set; }
    }

    public enum WorkflowTypes
    {
        Specimen,
        Case
    }

    /*
     * JSON includes rules for triggering workflow, relationships to other workflows, etc.
     */
}
