using CloudChatService.Core.DTOs.UserProfile;
using Microsoft.AspNetCore.Http;

namespace CloudChatService.Infrastructure.Repository.UserRepository.SheardMethods
{
    public static class SaveUserImage
    {
        public static string saveUserImage(string phoneNumber, IFormFile file)
        {
            string[] fileType = file.FileName.Split('.');
            string uniqueFileName = phoneNumber + "." + fileType.Last();
            var imagePath = Path.Combine(@"\\172.16.8.45\it\Chat_Media\UserProfileImage", uniqueFileName);

            MyCredentialManager.WriteCred();
            using (var iNeedToLearnAboutDispose = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(iNeedToLearnAboutDispose);
            }
            return imagePath;
        }
        public static ImageData getUserImage(string imagePath)
        {
            ImageData imageData = new ImageData();
            FileInfo fi = new FileInfo(imagePath);

            imageData.file = System.IO.File.ReadAllBytes(imagePath);
            imageData.name = fi.Name;
            imageData.Type = "image/jpg";

            return imageData;
        }

        public static async Task<string> saveFileInUserChatAsync(string phoneNumber, string partnerPhoneNumber, IFormFile file, int chatId)
        {
            string[] fileType = file.FileName.Split('.');
            string uniqueFileName = $"{fileType.First()}" + "." + fileType.Last();


            var imagePath = Path.Combine(@"\\172.16.8.45\it\Chat_Media\Chats\"+phoneNumber+@"\"+chatId+ @"\" + "Files", uniqueFileName);
            var imagePath2 = Path.Combine(@"\\172.16.8.45\it\Chat_Media\Chats\" + partnerPhoneNumber + @"\" + chatId + @"\" + "Files", uniqueFileName);

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
            
            //using (var iNeedToLearnAboutDispose = new FileStream(imagePath2, FileMode.Create))
            //{
            //    file.CopyTo(iNeedToLearnAboutDispose);
            //}
            return imagePath;
        }


    }

}