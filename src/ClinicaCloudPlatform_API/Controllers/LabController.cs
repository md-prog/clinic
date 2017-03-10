using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ClinicaCloudPlatform.DAL.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class LabController : Controller
    {
        [HttpGet("{orgNameKey}/{labId}")]
        public dynamic Labs(string OrgNameKey, int LabId)
        {
            foreach (dynamic lab in Labs(OrgNameKey))
            {
                if (lab.Id == LabId)
                    return lab;
            }
            return null;
        }

        [HttpGet("{orgNameKey}")]
        public dynamic Labs(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new DAL.Data.Functions.PostgreSQL(context);
                return pgHelper.GetLabsByOrganization(OrgNameKey).Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code
                });
            }
        }
    }
}
