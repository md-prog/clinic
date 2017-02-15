using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class BatchType : _LimsBaseClass
    {
        public string BatchTypeName { get; set; }
        public string BatchPrefix { get; set; }
        public BatchItemTypes BatchItemType { get; set; }
        public BatchRestrictionTypes BatchRestrictionType { get; set; }
        public ICollection<TestType> TestTypes { get; set; }
        public ICollection<SpecimenType> SpecimentTypes { get; set; }
        public ICollection<SpecimenTransport> SpecimenTransports { get; set; }
        public Workflow BatchOperationalWorkflow { get; set; }
        public Step StartingStep { get; set; }
        public Step FinalStep { get; set; }
        public bool AllowAddOnStartingStepOnly { get; set; }       
        public enum BatchItemTypes
        {
            Specimen,
            Test
        }
        public enum BatchRestrictionTypes
        {
            TestType,
            SpecimenType,
            SpecimenTypeAndTransport
        }

        /*******
            JSON data to include extended attributes to be displayed or entered for batches of this type
            Also include operational instructions
            definitely needed:
             - statuses (e.g. cancelled, complete)
        *******/

    }
}
