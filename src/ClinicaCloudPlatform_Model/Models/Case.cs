using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class Case : _LimsBaseClass
    {
        public string CaseNumber { get; set; }
        public ICollection<Specimen> Specimens { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
        public ICollection<PanelResult> PanelResults { get; set; }    
        public Lab ProcessingLab { get; set; }
        public Lab AnalysisLab { get; set; }
        public Lab ProfessionalLab { get; set; }

        /******
         * JSON Data will include case-level data entry and display fields
         ******/
    }
}
