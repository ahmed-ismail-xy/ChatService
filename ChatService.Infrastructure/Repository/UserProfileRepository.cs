using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Core.IDBServices;
using CloudChatService.Core.Services;
using CloudChatService.Infrastructure.Repository.UserRepository.SheardMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace CloudChatService.Infrastructure.Repository
{
    public partial class UserProfileRepository : IUserProfileService
    {
        private readonly IConfiguration _configuration;
        private readonly IDBUserService _dBUserService;
        public UserProfileRepository(IConfiguration configuration, IDBUserService dBUserService)
        {
            _configuration = configuration;
            _dBUserService = dBUserService;
        }

        public async Task<UpdateUserInfoDTO.Response> UpdateUserInfo(string phoneNumber, UpdateUserInfoDTO.Request request)
        {
            UpdateUserInfoDTO.Response responses = new UpdateUserInfoDTO.Response();
            bool result;
            var user = _dBUserService.GetUserData(phoneNumber);
            if (user.UserInfoId == 0 || user is null)
            {
                responses.APIResponses.Add(new(message: "UpdateUserInfo: User Not Found", erorrNumber: 1));
                return responses;
            }

            // Update User Password
            if (request.Password != String.Empty || request.Password.Trim().Length >= 6)
            {
                result = _dBUserService.UpdateUserInfo(phoneNumber: phoneNumber, userPassword: request.Password);

                if (result)
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: Password Updated", erorrNumber: 0));
                else
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: Password Cannot Updated", erorrNumber: 1));
            }

            // Update User Bio
            if (request.Bio.Trim().Length > 0 || request.Bio != String.Empty)
            {
                result = _dBUserService.UpdateUserInfo(phoneNumber: phoneNumber, userBio: request.Bio);

                if (result)
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: Bio Updated", erorrNumber: 0));
                else
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: Bio Cannot Updated", erorrNumber: 1));
            }

            // Update User FirstName
            if (request.FirstName != String.Empty || request.FirstName.Trim().Length > 0)
            {
                result = _dBUserService.UpdateUserInfo(phoneNumber: phoneNumber, firstName: request.FirstName);

                if (result)
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: FirstName Updated", erorrNumber: 0));
                else
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: FirstName Cannot Updated", erorrNumber: 1));
            }

            // Update User LastName
            if (request.LastName != String.Empty || request.LastName.Trim().Length > 0)
            {
                result = _dBUserService.UpdateUserInfo(phoneNumber: phoneNumber, lastName: request.LastName);

                if (result)
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: LastName Updated", erorrNumber: 0));
                else
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: LastName Cannot Updated", erorrNumber: 1));
            }

            // Update User FireToken
            if (request.FireToken != String.Empty || request.FireToken.Trim().Length > 0)
            {
                result = _dBUserService.UpdateUserInfo(phoneNumber: phoneNumber, fireToken: request.FireToken);

                if (result)
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: FireToken Updated", erorrNumber: 0));
                else
                    responses.APIResponses.Add(new(message: "UpdateUserInfo: FireToken Cannot Updated", erorrNumber: 1));
            }

            //// Update User UserPrivacyId
            //if (!(userProfile.UserPrivacyId < 0))
            //{
            //    result = _userDataService.UpdateUserInfo(phoneNumber: phoneNumber, userPrivacyId: userProfile.UserPrivacyId);
            //    response = response.responseHandler(result: result, requestName: "UpdateUserInfo: UserPrivacyId", erorrNumber: 1); 
            //    responses.Add(response);
            //}

            //// Update User AccountStateId
            //if (!(userProfile.AccountStateId < 0))
            //{
            //    result = _userDataService.UpdateUserInfo(phoneNumber: phoneNumber, accountStateId: userProfile.AccountStateId);
            //    response.responseHandler(result: result, requestName: "UpdateUserInfo: AccountStateId", erorrNumber: 1);
            //    responses.Add(response);
            //}


            return responses;
        }

        public async Task<APIResponse<ImageData>> GetUserImageAsync(string phoneNumber)
        {
            var user = _dBUserService.GetUserData(phoneNumber);

            if (user.UserImageName is not null || user.UserImageName.Length <= 10 || user.UserImageName != string.Empty)
            {
                return new(message: "GetUserImage: User Image", erorrNumber: 0)
                {
                    Data = SaveUserImage.getUserImage(user.UserImageName)
                };
            }
            return new(message: "GetUserImage: cannot get user Image", erorrNumber: 1);
        }
        public async Task<APIResponse> UpdateUserImageAsync(string phoneNumber, IFormFile file)
        {
            var user = _dBUserService.GetUserData(phoneNumber);
            if (user.UserInfoId == 0 || user is null)
            {
                return new(message: "UpdateUserImage: User Not Found", erorrNumber: 1);
            }


            string imagePath = SaveUserImage.saveUserImage(phoneNumber, file);
            var result = _dBUserService.UpdateUserInfo(phoneNumber: phoneNumber, userImage: imagePath);
            if (result)
                return new(message: "UpdateUserImage: " + imagePath, erorrNumber: 0);
            else
                return new(message: "UpdateUserImage: Image cannot Updated", erorrNumber: 1);
        }

        public async Task<APIResponse<UserDTO>> GetUserData(string phoneNumber)
        {
            UserDTO user = new UserDTO();
            user = _dBUserService.GetUserData(phoneNumber);
            if (user.PhoneNumber.Length < 1 || user == null)
            {
                return new(message: "GetUserData: User Not Found", erorrNumber: 1);
            }
            else if (user.UserImageName is not null || user.UserImageName.Length >= 10 || user.UserImageName != string.Empty)
            {
                ImageData imageData = SaveUserImage.getUserImage(user.UserImageName);
                user.UserImage = imageData.file;
                user.UserImageName = imageData.name;
                return new(message: "GetUserData: User Data", erorrNumber: 0)
                {
                    Data = user
                };
            }
            return new(message: "GetUserData: cannot get user data", erorrNumber: 1);
        }
        public async Task<APIResponse> DeleteUserImageAsync(string phoneNumber)
        {
            var user = _dBUserService.GetUserData(phoneNumber);
            if (user.UserInfoId == 0 || user is null)
            {
                return new(message: "DeleteUserImage: User Not Found", erorrNumber: 1);

            }
            bool result = _dBUserService.DeleteUserImage(phoneNumber);

            if (result)
                return new(message: "DeleteUserImage: User Image Deleted", erorrNumber: 0);
            else
                return new(message: "UpdateUserInfo: User Image Cannot Deleted", erorrNumber: 1);

        }
        public async Task<APIResponse> DeleteUserAsync(string phoneNumber)
        {
            var userInfo = _dBUserService.GetUserData(phoneNumber);
            if (userInfo.UserInfoId == 0 || userInfo is null)
            {
                return new(message: "DeleteUser: User Not Found", erorrNumber: 1);
            }

            bool result = _dBUserService.DeleteUser(phoneNumber);

            if (result)
                return new(message: "DeleteUser: User Deleted", erorrNumber: 0);
            else
                return new(message: "DeleteUser: User Cannot Deleted", erorrNumber: 1);
        }
    }
}
