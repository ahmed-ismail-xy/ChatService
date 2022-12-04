using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.UserProfile
{
    public class UpdateUserInfoDTO
    {
        public class Request
        {
           private Request()
            {
                FirstName = String.Empty;
                LastName = String.Empty;
                Password = String.Empty;
                PhoneNumber = String.Empty;
                Bio = String.Empty;
                FireToken = String.Empty;
                UserImage = String.Empty;
                UserPrivacyId = 0;
                AccountStateId = 0;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string PhoneNumber { get; set; }
            public string Bio { get; set; }
            public string FireToken { get; set; }
            public string UserImage { get; set; }
            public int UserPrivacyId { get; set; }
            public int AccountStateId { get; set; }
            
        }
        public class Response
        {
            public List<APIResponse> APIResponses = new List<APIResponse>();
        }

    }
}
