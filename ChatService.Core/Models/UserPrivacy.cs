using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class UserPrivacy
    {
        UserPrivacy()
        {
            this.UserInfos = new HashSet<UserInfo>();
        }
        public int UserPrivacyId { get; set; }


        public Nullable<int> ProfileImagePrivacyId { get; set; }
        public virtual ProfileImagePrivacy ProfileImagePrivacy { get; set; }
        public Nullable<int> LastSeenPrivacyId { get; set; }
        public virtual LastSeenPrivacy LastSeenPrivacy { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
