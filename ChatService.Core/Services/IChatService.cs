using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Chat;


namespace CloudChatService.Core.Services
{
    public interface IChatService
    {
        Task<APIResponse<GetAllUsersDTO.Response>> GetAllUsersAsync(string phoneNumber);
        Task<APIResponse<GetAllChatsDTO.Response>> GetAllChatsAsync(string phoneNumber);
        Task<APIResponse<CheckIsChatExistAndCreateItDTO.Response>> CheckIsChatExistOrCreateItAsync(CheckIsChatExistAndCreateItDTO.Request request);
        Task<APIResponse> UpdateChatAsync();
        Task<APIResponse> DeleteChatAsync();
    }
}
