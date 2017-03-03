using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Accession :_ApiModelBaseClass
    {
        public int PatientId { get; set; }
        public int ClientId { get; set; }
        public int FacilityId { get; set; }
        public int Doctor1Id { get; set; }
        public int Doctor2Id { get; set; }
        public string MRN { get; set; }
        public int OrderingLabId { get; set; }

        public IEnumerable<Case> Cases { get; set; }
        public IEnumerable<Specimen> Specimens { get; set; }

        /*****************
        For Accessions, the following will be stored as JSON Extended data:
        - Diagnosis Code/Disease/Reason For Referral
        - Custom Accession Data Attributes/Fields
        - Custom Statuses (e.g. Hold, Stat)
        - Case References
        - Specimen References

        JSON Schema for above should be stored/exposed as JsonExtendedDataSchema and data as CustomData
        *****************/

    }
}
