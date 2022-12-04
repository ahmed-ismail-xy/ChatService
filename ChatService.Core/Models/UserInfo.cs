using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? UserImage { get; set; }
        public string? Bio { get; set; }
        public string? FireToken { get; set; }
        public string? CreateAt { get; set; }
        public string? DeleteAt { get; set; }


        public Nullable<int> UserPrivacyId { get; set; }
        public virtual UserPrivacy UserPrivacy { get; set; }
        public Nullable<int> AccountStateId { get; set; }
        public virtual AccountState AccountState { get; set; }
    }
}
