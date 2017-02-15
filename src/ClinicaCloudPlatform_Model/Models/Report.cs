using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Report : _LimsBaseClass
    {
        public ReportTemplate ReportTemplate { get; set; }
        public int ReportVersion { get; set; }
        public string ReportVersionNotes { get; set; }
        public ICollection<ReportDocument> ReportDocuments { get; set; }
        public Case Case { get; set; }
        /*
         * JSON should contain the entire report payload - it is the main "report"
         */
    }

    public enum ReportDocumentTypes
    {
        MSWord,
        PDF,
        HTML,
        Text
    }
}
