using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class Group
    {
        Group()
        {
            this.GroupMembers = new HashSet<GroupMember>();
        }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupImage { get; set; }
        public string GroupBio { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}
