using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.Chat
{
    public class ChatDTO
    {
        public int ChatId { get; set; }
        public int UserInfoId { get; set; }
        public string UserPhone { get; set; }
        public string ChatName { get; set; }
        public string ChatImageName { get; set; }
        public byte[] ChatImage { get; set; }
        public string LastMessage { get; set; }
        public int LastMessageTypeId { get; set; }
        public string LastMessageTime { get; set; }
        public int UnreadMessagesCount { get; set; }
        public string ChatStateName { get; set; }
        public string MessageTypeName { get; set; }
    }
}
