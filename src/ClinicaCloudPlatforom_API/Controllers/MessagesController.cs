using ClinicaCloudPlatform.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {

        [HttpGet("[action]")]
        public ClientState Get()
        {
            var initialMessages = FakeMessageStore.FakeMessages.OrderByDescending(m => m.Date).Take(2);

            var initialValues = new ClientState()
            {
                Messages = initialMessages,
                LastFetchedMessageDate = initialMessages.Last().Date
            };

            return initialValues;
        }

        [HttpGet("[action]/{LastFetchedMessageDate}")]
        public IEnumerable<Message> FetchNextMessage(DateTime LastFetchedMessageDate)
        {
            return FakeMessageStore.FakeMessages.OrderByDescending(m => m.Date).SkipWhile(m => m.Date >= LastFetchedMessageDate).Take(1);
        }
    }
}
