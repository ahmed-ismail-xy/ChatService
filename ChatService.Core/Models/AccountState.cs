using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class AccountState
    {
        AccountState()
        {
            this.UserInfos = new HashSet<UserInfo>();
        }
        public int AccountStateId { get; set; }
        public string AccountStateName { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
