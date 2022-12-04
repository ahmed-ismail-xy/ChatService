
namespace CloudChatService.Core.DTOs.UserProfile
{
    public class UserDTO
    {
        public int UserInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string FireToken { get; set; }
        public string UserImageName { get; set; }
        public byte[] UserImage { get; set; }
        public int UserPrivacyId { get; set; }
        public int AccountStateId { get; set; }
    }
}
