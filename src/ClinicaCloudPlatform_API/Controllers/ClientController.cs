using ClinicaCloudPlatform.DAL.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        [HttpGet("{orgNameKey}/{ClientId}")]
        public dynamic Clients(string OrgNameKey, int ClientId)
        {
            foreach (dynamic client in Clients(OrgNameKey))
            {
                if (client.Id == ClientId)
                    return client;
            }
            return null;
        }

        [HttpGet("{orgNameKey}")]
        public dynamic Clients(string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var pgHelper = new DAL.Data.Functions.PostgreSQL(context);
                return pgHelper.GetClientsByOrganization(OrgNameKey).Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Facilities = c.Facilities.Select(f => new
                    {
                        Id = f.Id,
                        Name = f.Name
                    }
                    )
                });
            }
        }
    }
}
