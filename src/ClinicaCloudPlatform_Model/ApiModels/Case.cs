using System.Collections.Generic;
using System;

namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Case : _ApiModelBaseClass
    {
        public string CaseNumber { get; set; }
        public string Type { get; set; }
        public IEnumerable<Guid> SpecimenGuids { get; set; }
        public IEnumerable<TestResult> TestResults { get; set; }
        public IEnumerable<PanelResult> PanelResults { get; set; }    
        public int ProcessingLabId { get; set; }
        public int AnalysisLabId { get; set; }
        public int ProfessionalLabId { get; set; }
        public string CustomData { get; set; }

        /******
         * JSON Data will include case-level data entry and display fields
         ******/
    }
}
