using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class MessageState
    {
        MessageState()
        {
            this.Messages =new HashSet<Message>();
        }
        public int MessageStateId { get; set; }
        public string MessageStateName { get; set; }

        
        public virtual ICollection<Message> Messages { get; set; }
    }
}
