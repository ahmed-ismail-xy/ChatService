using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.Chat
{
    public class CheckIsChatExistAndCreateItDTO
    {
        public class Request
        {
            [Required]
            public int ReceiverId { get; set; }
            [Required]
            public int SenderId { get; set; }
        }
        public class Response
        {
            public int ChatId { get; set; }
        }
    }
}
