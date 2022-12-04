using CloudChatService.Core.DTOs.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.Chat
{
    public class GetAllUsersDTO
    {
        public class Response
        {
            public List<UserDTO> Users = new List<UserDTO>();
        }
    }
}
