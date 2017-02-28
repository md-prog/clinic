using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaCloudPlatform.Model.Models
{
    public interface ITypeSequenced
    {
        string Type { get; set; }
        int CurrentTypeSequenceNumber { get; set; }
    }
}
