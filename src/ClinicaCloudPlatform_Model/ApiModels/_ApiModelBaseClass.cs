using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public abstract class _ApiModelBaseClass
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedFullName { get; set; }
    }
}
