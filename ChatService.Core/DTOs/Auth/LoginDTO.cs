using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.Auth
{
    public class LoginDTO
    {
        public class Request
        {
            [Required]
            [StringLength(14)]
            public string PhoneNumber { get; set; }
            [Required]
            [StringLength(15, MinimumLength = 6)]
            public string Password { get; set; }
        }
        public class Response
        {
            public string status { get; set; }
            public string Token { get; set; }
            public DateTime ExpireDate { get; set; }
        }
    }
}