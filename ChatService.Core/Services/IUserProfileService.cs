using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.UserProfile;
using Microsoft.AspNetCore.Http;

namespace CloudChatService.Core.Services
{
    public interface IUserProfileService
    {
        Task<UpdateUserInfoDTO.Response> UpdateUserInfo(string phoneNumber, UpdateUserInfoDTO.Request request);
        Task<APIResponse> UpdateUserImageAsync(string pnoneNumber, IFormFile file);
        Task<APIResponse<UserDTO>> GetUserData(string phoneNumber);
        Task<APIResponse<ImageData>> GetUserImageAsync(string phoneNumber);
        Task<APIResponse> DeleteUserImageAsync(string pnoneNumber);
        Task<APIResponse> DeleteUserAsync(string pnoneNumber);
    }
}
