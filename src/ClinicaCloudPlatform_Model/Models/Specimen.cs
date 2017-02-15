using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Specimen : _LimsBaseClass
    {
        public string ExternalSpecimenID { get; set; }
        public string SpecimenCode { get; set; }
        public SpecimenType SpecimenType { get; set; }
        public SpecimenTransport SpecimenTransport { get; set; }
        public ICollection<Specimen> ChildSpecimens { get; set; }
        public ICollection<Comment> Comments { get; set; }

        /*
         * JSON contains specimen data fields 
         */
    }
}
