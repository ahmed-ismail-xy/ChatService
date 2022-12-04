using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class UserRole
    {
        UserRole()
        {
            this.GroupMembers = new HashSet<GroupMember>();
        }
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}
