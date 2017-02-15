using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.Models
{
    public class ReportTemplate : _LimsBaseClass
    {
        public string ReportTemplateName { get; set; }

        /// <summary>
        /// Probably a Jasper JRXML definition
        /// </summary>
        public string ReportTemplateDefinition { get; set; }

        public bool PublicReport { get; set; }

        public ICollection<CaseType> CaseTypes { get; set; }
              
        //public ICollection<ReportDocumentTypes> DocumentTypesToGenerate { get; set; }
       
        /*
         * JSON: Document types to generate, and more I'm sure
         */

    }
}
