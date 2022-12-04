using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class ChatType
    {
        ChatType()
        {
            this.Chats = new HashSet<Chat>();
        }
        public int ChatTypeId { get; set; }
        public string ChatTypeName { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}
