using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class Chat
    {
        public Chat()
        {
            this.ChatMembers = new HashSet<ChatMember>();
            this.Messages = new HashSet<Message>();

        }

        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public string ChatImage { get; set; }
        public string LastMessage { get; set; }
        public int UnreadMessageCount { get; set; }
        public DateTime LastMessageTime { get; set; }
        public int LastMessageSenderId { get; set; }

        public Nullable<int> MessageTypeId { get; set; }
        public virtual MessageType MessageType { get; set; }

        public Nullable<int> ChatTypeId { get; set; }
        public virtual ChatType ChatType { get; set; }

        public Nullable<int> ChatStateId { get; set; }
        public virtual ChatState ChatState { get; set; }

        public virtual ICollection<ChatMember> ChatMembers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
