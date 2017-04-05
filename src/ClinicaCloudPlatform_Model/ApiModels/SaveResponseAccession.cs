using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class SaveResponseAccession : _ApiResponseBaseClass
    {
        public List<SaveResponseSpecimen> SpecimensInfo { get; set; }
        public List<SaveResponseCase> CasesInfo { get; set; }

    }
}
