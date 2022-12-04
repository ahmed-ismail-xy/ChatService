using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class LastSeenPrivacy
    {
        LastSeenPrivacy()
        {
            this.UserPrivacies = new HashSet<UserPrivacy>();
        }
        public int LastSeenPrivacyId { get; set; }
        public string LastSeenPrivacyName { get; set; }

        public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
    }
}
