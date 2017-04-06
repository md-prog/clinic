using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public abstract class _ApiRequestBaseClass
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string OrgNameKey { get; set; }
    }
}
