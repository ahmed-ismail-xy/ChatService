using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class ProfileImagePrivacy
    {
        ProfileImagePrivacy()
        {
            this.UserPrivacies = new HashSet<UserPrivacy>();
        }
        public int ProfileImagePrivacyId { get; set; }
        public string ImagePrivacy { get; set; }


        public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
    }
}
