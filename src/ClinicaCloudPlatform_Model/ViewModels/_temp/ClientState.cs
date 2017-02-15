
using System;
using System.Collections.Generic;

namespace ClinicaCloudPlatform.Model.ViewModels
{
    public class ClientState
    {
        public IEnumerable<Message> Messages { get; set; }
        
        public DateTime LastFetchedMessageDate { get; set; }
    }
}
