using System.Collections.Generic;

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
