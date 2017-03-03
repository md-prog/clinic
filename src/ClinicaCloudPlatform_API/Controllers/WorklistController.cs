using Microsoft.AspNetCore.Mvc;
using ClinicaCloudPlatform.DAL.Data;
using System.Linq;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class WorklistController : Controller
    {
        public class WorklistOptions
        {
            public bool IncludeCases { get; set; }
            public bool IncludeSpecimens { get; set; }
        }

        [HttpGet("{orgNameKey}/{Start}/{End}/{Options}")]
        public dynamic Get(string OrgNameKey, DateTime Start, DateTime End, string Options)
        {
            var options = JObject.Parse(Options).ToObject<WorklistOptions>();
            using (var context = new ArsMachinaLIMSContext())
            {
                //EF at its crappiest
                var query = context.Accessions
                    .Include(a => a.Client)
                    .ThenInclude(c => c.Facilities)
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor1)
                    .Include(a => a.Doctor2)
                    .Include(a => a.Facility)
                    .Include(a => a.OrderingLab).AsQueryable();

                if (options.IncludeCases)
                {
                    query = query.Include(a => a.Cases)
                    .ThenInclude(c => c.Specimens)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.PanelResults)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.TestResults)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.ProcessingLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.ProfessionalLab)
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.AnalysisLab);
                }

                if (options.IncludeSpecimens)
                {
                    query = query
                    .Include(a => a.Cases)
                    .ThenInclude(c => c.Specimens)
                    .Include(a => a.Specimens);
                }

                return query.Select(a => Mapping.Accession.GetAccessionApiModel(a, 
                    new Mapping.AccessionMapOptions() {
                        IncludeCases = options.IncludeCases,
                        IncludeSpecimens = options.IncludeSpecimens }))
                    .ToList();                
            }
        }
    }
}
