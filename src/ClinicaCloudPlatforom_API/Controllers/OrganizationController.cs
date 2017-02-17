using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stormpath.SDK;
using Stormpath.SDK.Group;
using Stormpath.SDK.Organization;
using Stormpath.SDK.Directory;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IClient _stormpathClient;

        public OrganizationController(IClient stormpathClient, Lazy<IAccount> stormpathAccount)
        {
            _stormpathClient = stormpathClient;
        }
        
        [HttpGet("[action]")]
        public dynamic Get()
        {
            var subDomain = string.Empty;

            var host = HttpContext.Request.Host.Host;

            if (!string.IsNullOrWhiteSpace(host))
            {
                subDomain = host.Split('.')[0];
            }

            //default to clinica base app
            var orgNameKey = (new string[]{ string.Empty, "www", "localhost"}).Contains(subDomain) ? "clinica" : subDomain;

            var org = _stormpathClient.GetOrganizationByNameKeyAsync(orgNameKey).Result;
            var dir = (IDirectory)org.GetDefaultGroupStoreAsync().Result;
            
            var orgViewModel = new
            {
                Href = org.Href,
                Name = org.Name,
                NameKey = org.NameKey,
                Groups = dir.GetGroups().ToListAsync().Result.Select(g => new
                {
                    Name = g.Name,
                    Users = GetAccounts(org, g).Select(u=> new
                    {
                        Href = u.Href,
                        Email = u.Email,
                        FullName = u.FullName
                    })
                })
            };

            return orgViewModel;
        }

        // POST api/values
        [HttpPost("[action]")]
        public void Save([FromBody]dynamic value)
        {
        }

        private List<IAccount> GetAccounts(IOrganization Organization, IGroup Group)
        {
            //this will need a performance rewrite
            var retVal = new List<IAccount>();
            var allAccounts = Group.GetAccounts().ToListAsync().Result;
            foreach(var account in allAccounts)
            {
                var orgs = account.GetCustomDataAsync().Result["organizationNameKeys"];
                if(orgs!=null)
                {
                    if (((string[])orgs).Contains(Organization.NameKey))
                        retVal.Add(account);
                }
            }
            return retVal;
        }
    }
}
