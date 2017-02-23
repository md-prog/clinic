using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using YamlDotNet.Serialization;
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
            var customData = org.GetCustomDataAsync().Result;

            var dir = _stormpathHelper.GetDirectory(org);

            dynamic orgViewModel = new
            {
                Href = org.Href,
                Name = org.Name,
                NameKey = org.NameKey,
                Groups = _stormpathHelper.GetGroups(dir).Select(g => new
                {
                    Name = g.Name,
                    Users = _stormpathHelper.GetAccounts(org, g).Select(u => new
                    {
                        Href = u.Href,
                        Email = u.Email,
                        FullName = u.FullName
                    })
                }),
                CustomData = new
                {
                    SomeMissingProp = customData["someMissingProp"],
                    LogoUrl = customData["logoUrl"],
                    CaseTypeDefinitions = customData["caseTypeDefinitions"],
                    PanelDefinitions = customData["panelDefinitions"],
                    TestDefinitions = customData["testDefinitions"],
                    SpecimenDefinitions = customData["specimenDefinitions"],
                    SpecimenAccessionSections = customData["specimenAccessionSections"]
                }
            };

            //stormpath dumps this out in key/value pairs instead of their native json format. w t f.
            //if (customData.ContainsKey("logoUrl"))
            //    orgViewModel.LogoUrl = customData["logoUrl"];
            //if (customData.ContainsKey("caseTypeDefinitions"))
            //    orgViewModel.CaseTypeDefinitions = customData["caseTypeDefinitions"];
            //if (customData.ContainsKey("panelDefinitions"))
            //    orgViewModel.PanelDefinitions = customData["panelDefinitions"];
            //if (customData.ContainsKey("testDefinitions"))
            //    orgViewModel.TestDefinitions = customData["testDefinitions"];
            //if (customData.ContainsKey("specimenDefinitions"))
            //    orgViewModel.SpecimenDefinitions = customData["specimenDefinitions"];
            //if (customData.ContainsKey("specimenAccessionSections"))
            //    orgViewModel.SpecimenAccessionSections = customData["specimenAccessionSections"];

            //var client = new System.Net.Http.HttpClient();
            //var authPayload = string.Format("{0}:{1}", API_KEY_ID, API_KEY_SECRET);
            //var authPayloadEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(authPayload));
            //request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authPayloadEncoded);
            //var jsonResult = client.GetAsync(org.Href + "/customData").Result;

            return orgViewModel;
        }

        // POST api/values
        [HttpPost("[action]")]
        public void Save([FromBody]dynamic value)
        {
        }

    }
}
