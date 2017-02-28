using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public abstract class _ApiModelBaseClass
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
    }
}
