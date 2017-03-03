using ClinicaCloudPlatform.DAL.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        [HttpGet("{orgNameKey}")]
        public dynamic Get(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new DAL.Data.Functions.PostgreSQL(context);
                return pgHelper.GetDoctorsByOrganization(OrgNameKey).Select(p => new
                {
                    Id = p.Id,
                    LastName = p.LastName,
                    FirstName = p.FirstName
                });
            }
        }
    }
}
