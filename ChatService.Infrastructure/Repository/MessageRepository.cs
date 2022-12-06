using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Message;
using CloudChatService.Core.IDBServices;
using CloudChatService.Core.Services;
using CloudChatService.Infrastructure.Repository.UserRepository.Helper;
using Microsoft.AspNetCore.Http;


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
                if (message.HasFiles)
                {
                    foreach (var file in message.filesList.Files)
                    {
                        string path = await SaveUserFile.saveFileInUserChatAsync(phoneNumber: phoneNumber, receiverPhoneNumber: message.ReceiverPhoneNumber, file: file, chatId: message.ChatId);
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

        //#region Download File  
        //public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
        //{
        //    var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

        //    var files = Directory.GetFiles(Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory)).ToList();

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var archive = new ZipArchive(memoryStream, File.Create, true))
        //        {
        //            files.ForEach(file =>
        //            {
        //                var theFile = archive.CreateEntry(file);
        //                using (var streamWriter = new StreamWriter(theFile.Open()))
        //                {
        //                    streamWriter.Write(File.ReadAllText(file));
        //                }

        //            });
        //        }

        //        return ("application/zip", memoryStream.ToArray(), zipName);
        //    }

        //}
        //#endregion
    }
}
