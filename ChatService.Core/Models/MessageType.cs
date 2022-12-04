using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class MessageType
    {
        MessageType()
        {
            this.Chats = new HashSet<Chat>();
            this.Messages = new HashSet<Message>();
        }

        public int MessageTypeId { get; set; }
        public string MessageTypeName { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
