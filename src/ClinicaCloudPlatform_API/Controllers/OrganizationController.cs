using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        private Controller_Helpers.Stormpath _stormpathHelper;

        public OrganizationController(IClient stormpathClient, Lazy<IAccount> stormpathAccount, IHttpContextAccessor HttpContextAccessor)
        {
            _stormpathHelper = new Controller_Helpers.Stormpath(stormpathClient, stormpathAccount, HttpContextAccessor);
        }
        
        [HttpGet("[action]")]
        public dynamic Get()
        {
            var org = _stormpathHelper.GetOrganization();

            var dir = _stormpathHelper.GetDirectory(org);
            
            var orgViewModel = new
            {
                Href = org.Href,
                Name = org.Name,
                NameKey = org.NameKey,
                Groups = _stormpathHelper.GetGroups(dir).Select(g => new
                {
                    Name = g.Name,
                    Users = _stormpathHelper.GetAccounts(org, g).Select(u=> new
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

    }
}
