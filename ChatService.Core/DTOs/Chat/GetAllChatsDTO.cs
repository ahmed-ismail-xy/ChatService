using CloudChatService.Core.DTOs.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.Chat
{
    public class GetAllChatsDTO
    {
        public class Response
        {
            public List<ChatDTO> Chats = new List<ChatDTO>();
        }
    }
}
