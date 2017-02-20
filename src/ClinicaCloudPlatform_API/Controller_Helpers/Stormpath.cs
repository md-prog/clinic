using System;
using System.Collections.Generic;
using System.Linq;
using Stormpath.SDK;
using Stormpath.SDK.Group;
using Stormpath.SDK.Organization;
using Stormpath.SDK.Directory;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using Microsoft.AspNetCore.Http;

namespace ClinicaCloudPlatform.API.Controller_Helpers
{
    public class Stormpath
    {
        private readonly Lazy<IAccount> _stormPathAccount;
        private readonly IClient _stormpathClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public Stormpath(IClient StormpathClient, Lazy<IAccount> StormpathAccount, IHttpContextAccessor ContextAccessor)
        {
            _stormPathAccount = StormpathAccount;
            _stormpathClient = StormpathClient;
            _contextAccessor = ContextAccessor;
        }

        public IOrganization GetOrganization()
        {
            var subDomain = string.Empty;

            var host = _contextAccessor.HttpContext.Request.Host.Host;
            var orgNameKey = (new string[] { string.Empty, "www", "localhost" }).Contains(subDomain) ? "clinica" : subDomain;

            return _stormpathClient.GetOrganizationByNameKeyAsync(orgNameKey).Result;
        }

        public IDirectory GetDirectory(IOrganization Organization)
        {
            return (IDirectory)Organization.GetDefaultGroupStoreAsync().Result;
        }

        public List<IGroup> GetGroups(IDirectory Directory)
        {
            return Directory.GetGroups().ToListAsync().Result;
        }

        public List<IAccount> GetAccounts(IOrganization Organization, IGroup Group)
        {
            //this will need a performance rewrite
            var retVal = new List<IAccount>();
            var allAccounts = Group.GetAccounts().ToListAsync().Result;
            foreach (var account in allAccounts)
            {
                var orgs = account.GetCustomDataAsync().Result["organizationNameKeys"];
                if (orgs != null)
                {
                    if (((string[])orgs).Contains(Organization.NameKey))
                        retVal.Add(account);
                }
            }
            return retVal;
        }
    }
}
