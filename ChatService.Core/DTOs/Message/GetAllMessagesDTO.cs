using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.Message
{
    public class GetAllMessagesDTO
    {
        public class Response
        {
            public List<MessageDTO<byte[]>> Messages = new List<MessageDTO<byte[]>>();
        }
    }

}
