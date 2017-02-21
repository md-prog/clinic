using System;
using Microsoft.AspNetCore.Mvc;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IClient _stormpathClient;
        private readonly IAccount _stormpathAccount;

        public UserController(IClient stormpathClient, Lazy<IAccount> stormpathAccount)
        {
            // Stormpath request objects injected via DI
            _stormpathClient = stormpathClient;
            _stormpathAccount = stormpathAccount.Value;
        }

        // GET: api/values
        [HttpGet]
        public IAccount Get()
        {
            return _stormpathAccount;
        }

        [HttpPost("[action]/{Key}/{Value}")]
        public void UpdateCustomData(string Key, string Value)
        {
            _stormpathAccount.CustomData.Put(Key, Value);
            _stormpathAccount.SaveAsync();
        }

    }
}
