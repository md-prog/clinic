using System;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Audit
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public DateTime UtcDate { get; set; }
        public string DotNetTimeZone { get; set; }
        public AuditLevel AuditLevel { get; set; }
        public string Diff { get; set; }
    }

    public enum AuditLevel
    {
        UserDateOnly,
        FullAudit
    }

    public enum AuditLogReturnLevel
    {
        None,
        Created,
        LastModified,
        FullHistory
    }
}
