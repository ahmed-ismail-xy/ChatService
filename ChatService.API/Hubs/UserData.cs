using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.API.Hubs
{
    internal class UserData
    {
        public bool Active { get; set; }
        public string ConnectionId { get; set; }
        public int ConnectionNumber { get; set; }
        public DateTime ConnectedAt { get; set; }
    }
}
