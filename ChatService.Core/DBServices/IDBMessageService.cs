using CloudChatService.Core.DTOs.Message;
using Microsoft.AspNetCore.Http;

namespace CloudChatService.Core.IDBServices
{
    public interface IDBMessageService
    {
        GetAllMessagesDTO.Response GetAllMessagesByChatId(int chatId);
        bool SendMessage(MessageDTO<IFormFile> message, List<string> pathes = null);
        bool CheckFolders(int chatId, string myPhoneNumber, string partnerPhoneNumber);

    }
}
