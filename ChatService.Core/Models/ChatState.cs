using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class ChatState
    {
        ChatState()
        {
            this.Chats = new HashSet<Chat>();
        }
        public int ChatStateId { get; set; }
        public int ChatStateName { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}
