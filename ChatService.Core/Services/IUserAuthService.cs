using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Auth;
using CloudChatService.Infrastrucure.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Core.Services
{
    public interface IUserAuthService
    {
        Task<APIResponse<LoginDTO.Response>> LoginUserAsync(LoginDTO.Request request);
        Task<APIResponse> RegisterUserAsync(UserInfo userInfo, IFormFile userImage);
    }
}
