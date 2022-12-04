using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class ChatMember
    {
        public int ChatMemberId { get; set; }


        public Nullable<int> ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public Nullable<int> UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
