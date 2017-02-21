using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Workflow : _LimsBaseClass
    {
        public string WorkflowName { get; set; }
        public ICollection<Step> Steps { get; set; }
    }

    /*
     * JSON includes rules for triggering workflow, relationships to other workflows, etc.
     */
}
