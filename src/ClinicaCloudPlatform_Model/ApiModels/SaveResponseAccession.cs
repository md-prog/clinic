using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class SaveResponseAccession : _ApiResponseBaseClass
    {
        public List<SaveResponseGeneric> SpecimensInfo { get; set; }
        public List<SaveResponseCase> CasesInfo { get; set; }

    }
}
