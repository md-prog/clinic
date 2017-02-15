namespace ClinicaCloudPlatform.Model.Models
{
    public class Label : _LimsBaseClass
    {
        public string LabelName { get; set; }
        /// <summary>
        /// probably xml to be consumed by windows printer app - aka TFORMer
        /// </summary>
        public string BarcodeFormDefinition { get; set; }
        public LabelTypes LabelType { get; set; }
        /*
         * JSON should contain data payload for label
         */
    }
    public enum LabelTypes
    {
        Accession,
        Specimen,
        Case,
        Test
    }
}
