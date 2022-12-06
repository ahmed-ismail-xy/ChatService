using ChatService.Infrastructure.Repository.Helper;
using CloudChatService.Core.DTOs.UserProfile;
using Microsoft.AspNetCore.Http;

namespace CloudChatService.Infrastructure.Repository.UserRepository.Helper
{
    public static class SaveUserFile
    {
        public static string saveUserFile(string phoneNumber, IFormFile file)
        {
            string[] fileType = file.FileName.Split('.');
            string uniqueFileName = phoneNumber + "." + fileType.Last();
            var imagePath = Path.Combine(@"\\172.16.8.45\it\Chat_Media\UserProfileImage", uniqueFileName);

            MyCredentialManager.WriteCred();
            using (var Dispose = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(Dispose);
            }
            return imagePath;
        }
        public static ImageData getUserFile(string filePath)
        {
            ImageData imageData = new ImageData();
            FileInfo fi = new FileInfo(filePath);
            imageData.file = System.IO.File.ReadAllBytes(filePath);
            imageData.name = fi.Name;
            imageData.Type = MIMEAssistant.GetMIMEType(fileName: fi.Name);

            return imageData;
        }

        public static async Task<string> saveFileInUserChatAsync(string phoneNumber, string receiverPhoneNumber, IFormFile file, int chatId)
        {
            string[] fileType = file.FileName.Split('.');
            string uniqueFileName = $"{fileType.First()}" + "." + fileType.Last();


            var imagePath = Path.Combine(@"\\172.16.8.45\it\Chat_Media\Chats\"+phoneNumber+@"\"+chatId+ @"\" + "Files", uniqueFileName);
            var imagePath2 = Path.Combine(@"\\172.16.8.45\it\Chat_Media\Chats\" + receiverPhoneNumber + @"\" + chatId + @"\" + "Files", uniqueFileName);

            MyCredentialManager.WriteCred();
            try
            {
                await using var iNeedToLearnAboutDispose = new FileStream(imagePath, FileMode.Create);
                file.CopyTo(iNeedToLearnAboutDispose);
                iNeedToLearnAboutDispose.Dispose();

                await using var iNeedToLearnAboutDispose2 = new FileStream(imagePath2, FileMode.Create);
                file.CopyTo(iNeedToLearnAboutDispose2);
                iNeedToLearnAboutDispose2.Dispose();

            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
            
            return imagePath;
        }


    }

}