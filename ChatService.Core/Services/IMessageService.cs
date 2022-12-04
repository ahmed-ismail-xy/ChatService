using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Message;
using Microsoft.AspNetCore.Http;

namespace CloudChatService.Core.Services
{
    public interface IMessageService
    {
        Task<APIResponse> SendMessageAsync(string phoneNumber, MessageDTO<IFormFile> message);
        Task<APIResponse> DeleteMessageAsync(int messageId);
        Task<APIResponse<GetAllMessagesDTO.Response>> GetAllMessagesByChatIdAsync(int chatId);
    }
}
