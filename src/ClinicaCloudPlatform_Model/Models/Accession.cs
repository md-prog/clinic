using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Accession : _LimsBaseClass
    {
        public Patient Patient { get; set; }
        public Client Client { get; set; }
        public Facility Facility { get; set; }
        public Doctor Doctor1 { get; set; }
        public Doctor Doctor2 { get; set; }
        public string MRN { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Lab OrderingLab { get; set; }

        /*****************
        For Accessions, the following will be stored as JSON Extended data:
        - Diagnosis Code/Disease/Reason For Referral
        - Custom Accession Data Attributes/Fields
        - Custom Statuses (e.g. Hold, Stat)
        - Case References
        - Specimen References

        JSON Schema for above should be stored/exposed as JsonExtendedDataSchema and data as JsonExtendedData
        *****************/

    }
}
