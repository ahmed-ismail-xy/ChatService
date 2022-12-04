using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Chat;
using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Core.IDBServices;
using CloudChatService.Core.Services;
using CloudChatService.Infrastructure.Repository.UserRepository.SheardMethods;
using Microsoft.Extensions.Configuration;


namespace CloudChatService.Infrastructure.Repository
{
    public partial class ChatRepository : IChatService
    {
        private readonly IConfiguration _configuration;
        private readonly IDBChatService _dBChatService;
        public ChatRepository(IConfiguration configuration, IDBChatService dBChatService)
        {
            _configuration = configuration;
            _dBChatService = dBChatService;
        }
        public async Task<APIResponse<GetAllChatsDTO.Response>> GetAllChatsAsync(string phoneNumber)
        {
            GetAllChatsDTO.Response listOfChats = new GetAllChatsDTO.Response();
            listOfChats = _dBChatService.GetAllChats(phoneNumber);
            if (listOfChats.Chats.Count < 1)
            {
                return new(message: "GetAllChats: Chats Not Found", erorrNumber: 0);
            }
            else
            {
                foreach (var user in listOfChats.Chats)
                {
                    ImageData imageData = SaveUserImage.getUserImage(user.ChatImageName);
                    user.ChatImage = imageData.file;
                    user.ChatImageName = imageData.name;
                }
                return new(message: "GetAllChats: All Chats", erorrNumber: 0)
                {
                    Data = listOfChats
                };
            }
        }

        public async Task<APIResponse<GetAllUsersDTO.Response>> GetAllUsersAsync(string phoneNumber)
        {
            GetAllUsersDTO.Response ListOfUsers = new GetAllUsersDTO.Response();
            ListOfUsers = _dBChatService.GetAllUsers(phoneNumber);
            if (ListOfUsers.Users.Count < 1)
            {
                return new(message: "GetAllUsers: Users Not Found", erorrNumber: 1);
            }
            else
            {
                foreach (var user in ListOfUsers.Users)
                {
                    ImageData imageData = SaveUserImage.getUserImage(user.UserImageName);
                    user.UserImage = imageData.file;
                    user.UserImageName = imageData.name;
                }
                return new(message: "GetAllUsers: All Users", erorrNumber: 0)
                {
                    Data = ListOfUsers
                };
            }

        }

        public async Task<APIResponse<CheckIsChatExistAndCreateItDTO.Response>> CheckIsChatExistOrCreateItAsync(CheckIsChatExistAndCreateItDTO.Request request)
        {
            int result = _dBChatService.CheckIsChatExistAndCreateIt(request);
            if (result <= 0)
            {
                return new(message: "CheckIsChatExistOrCreateIt: Chat cannot be created", erorrNumber: 0);
            }
            else
            {
                return new(message: "CheckIsChatExistOrCreateIt: Chat Created", erorrNumber: 0)
                {
                    Data = new() { ChatId = result }
                };
            }
        }

        public async Task<APIResponse> DeleteChatAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<APIResponse> UpdateChatAsync()
        {
            throw new NotImplementedException();
        }
    }
}
