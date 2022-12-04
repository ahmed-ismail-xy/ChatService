using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Message;
using CloudChatService.Core.IDBServices;
using CloudChatService.Core.Services;
using CloudChatService.Infrastructure.Repository.UserRepository.SheardMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace CloudChatService.Infrastructure.Repository
{
    public class MessageRepository : IMessageService
    {
        private readonly IDBMessageService _dBMessageService;
        public MessageRepository(IDBMessageService dBMessageService)
        {
            _dBMessageService = dBMessageService;
        }

        public async Task<APIResponse> SendMessageAsync(string phoneNumber, MessageDTO<IFormFile> message)
        {
            var fileResult = _dBMessageService.CheckFolders(message.ChatId, phoneNumber, message.ReceiverPhoneNumber);
            if (fileResult)
            {
                List<string> pathesFiles = new List<string>();
                if (message.HasImages)
                {
                    foreach (var file in message.Files)
                    {
                        string path = await SaveUserImage.saveFileInUserChatAsync(phoneNumber: phoneNumber, partnerPhoneNumber: message.ReceiverPhoneNumber, file: file, chatId: message.ChatId);
                        pathesFiles.Add(path);
                    }
                }
                var result = _dBMessageService.SendMessage(message: message, pathes: pathesFiles);
                if (result)
                {
                    return new(message: $"SendMessage: Message sent", erorrNumber: 0);
                }
                else
                {
                    return new(message: "SendMessage: Message connot sent", erorrNumber: 1);
                }
            }
            else
            {
                return new(message: "SendMessage: Message connot senssssst + result -> " +fileResult, erorrNumber: 1);
            }

        }
        public async Task<APIResponse<GetAllMessagesDTO.Response>> GetAllMessagesByChatIdAsync(int chatId)
        {

            GetAllMessagesDTO.Response ListOfMessages = new GetAllMessagesDTO.Response();

            ListOfMessages = _dBMessageService.GetAllMessagesByChatId(chatId);
            if (ListOfMessages.Messages.Count < 1)
            {
                return new(message: "GetAllMessagesByChatId: No Messages Founded", erorrNumber: 0);
            }

            return new(message: "GetAllMessagesByChatId: All Messages", erorrNumber: 0)
            {
                Data = ListOfMessages
            };
        }
        public async Task<APIResponse> DeleteMessageAsync(int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
