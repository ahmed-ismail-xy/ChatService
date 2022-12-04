using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.DTOs.UserAuth
{
    public class RegisterDTO
    {
        public class Request
        {
            [Required]
            [StringLength(50)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50)]
            public string LastName { get; set; }

            [Required]
            [StringLength(15)]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(15, MinimumLength = 6)]
            public string Password { get; set; }

            [StringLength(100)]
            public string Bio { get; set; }

            [StringLength(100)]
            public string CreateAt { get; set; }

            [StringLength(2)]
            public string UserPrivacyId { get; set; }

            [StringLength(2)]
            public string AccountStateId { get; set; }

            [StringLength(200)]
            public string FireToken { get; set; }
            public IFormFile UserImage { get; set; }
        }
    }
}
