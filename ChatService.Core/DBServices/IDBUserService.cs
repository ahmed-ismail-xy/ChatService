using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Infrastrucure.Data;


namespace CloudChatService.Core.IDBServices
{
    public interface IDBUserService
    {
        UserDTO GetUserData(string phoneNumber);
        bool UpdateUserInfo(string phoneNumber, string userBio = null,
           string userImage = null, string firstName = null,
           string lastName = null, string userPassword = null,
           string fireToken = null, string deleteAt = null,
            string createAt = null
           );
        bool DeleteUserImage(string phoneNumber);
        bool DeleteUser(string phoneNumber);
        bool CreateUser(UserInfo userInfo, string imagePath);
    }
}
