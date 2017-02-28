using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class SaveResponseCase : _ApiResponseBaseClass
    {
        string CaseNumber;
        public IEnumerable<SaveResponseGeneric> PanelResultsInfo { get; set; }
        public IEnumerable<SaveResponseGeneric> TestResultsInfo { get; set; }
        public IEnumerable<SaveResponseGeneric> SpecimensInfo { get; set; }

    }
}
