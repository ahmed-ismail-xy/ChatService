using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class GroupMember
    {
        public int GroupMemberId { get; set; }


        public Nullable<int> UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public Nullable<int> GroupId { get; set; }
        public virtual Group Group { get; set; }
        public Nullable<int> UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
