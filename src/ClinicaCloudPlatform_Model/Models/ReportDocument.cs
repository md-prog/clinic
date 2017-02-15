namespace ClinicaCloudPlatform.Model.Models
{
    public class ReportDocument : _LimsBaseClass
    {
        public ReportDocumentTypes ReportDocumentType { get; set; }
        public byte[] ReportDocumentBinary { get; set; }
    }
}
