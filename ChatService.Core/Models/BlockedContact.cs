using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class BlockedContact
    {
        public int BlockedContactId { get; set; }
        public DateTime BlockedAt { get; set; }
        public int BlockedId { get; set; }


        public Nullable<int> UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
