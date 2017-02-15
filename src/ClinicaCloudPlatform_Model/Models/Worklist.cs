using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Worklist : _LimsBaseClass
    {
        public ICollection<WorklistColumn> AvailableColumns { get; set; }
        public WorklistTypes WorklistType { get; set; }

        /*
         * JSON includes STANDARD configuration
         * Per-user configuration stored in identity provider (stormpath)
         */
    }
    public enum WorklistTypes
    {
        Specimen,
        Case
    }
}
