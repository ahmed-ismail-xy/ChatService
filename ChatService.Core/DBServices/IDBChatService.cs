using CloudChatService.Core.DTOs.Chat;

namespace CloudChatService.Core.IDBServices
{
    public interface IDBChatService
    {
        GetAllChatsDTO.Response GetAllChats(string phoneNumber);
        GetAllUsersDTO.Response GetAllUsers(string phoneNumber);
        int CheckIsChatExistAndCreateIt(CheckIsChatExistAndCreateItDTO.Request request);
    }
}
