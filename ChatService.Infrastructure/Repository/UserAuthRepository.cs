using CloudChatService.Core.DTOs;
using CloudChatService.Core.DTOs.Auth;
using CloudChatService.Core.IDBServices;
using CloudChatService.Core.Services;
using CloudChatService.Infrastructure.Data;
using CloudChatService.Infrastructure.Repository.UserRepository.SheardMethods;
using CloudChatService.Infrastrucure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CloudChatService.Infrastructure.Repository
{
    public partial class UserAuthRepository : IUserAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IDBUserService _dBUserService;

        public UserAuthRepository(IConfiguration configuration, IDBUserService dBUserService)
        {
            _configuration = configuration;
            _dBUserService = dBUserService;
        }
        public async Task<APIResponse> RegisterUserAsync(UserInfo userInfo, IFormFile userImage)
        {
            var user = _dBUserService.GetUserData(phoneNumber: userInfo.PhoneNumber);

            if (user.UserInfoId != 0 || user is not null)
            {
                return new(message: "User Already Exist", erorrNumber: 0);
            }

            string imagePath = SaveUserImage.saveUserImage(userInfo.PhoneNumber, userImage);

            bool changes = _dBUserService.CreateUser(userInfo: userInfo, imagePath);

            if (changes)
            {
                return new(message: "RegisterUser: User Cannot Register", erorrNumber: 0);
            }

            return new(message: "RegisterUser: User Registered", erorrNumber: 0);
        }
        public async Task<APIResponse<LoginDTO.Response>> LoginUserAsync(LoginDTO.Request request)
        {
            var userInfo = _dBUserService.GetUserData(request.PhoneNumber);
            if (userInfo.UserInfoId == 0 || userInfo is null)
            {
                return new APIResponse<LoginDTO.Response>(message: "LoginUser: Invalid PhoneNumber", erorrNumber: 0);
            }
            string userPassword = userInfo.Password;

            if (!userPassword.Equals(request.Password))
            {
                return new APIResponse<LoginDTO.Response>(message: "LoginUser: Invalid Password", erorrNumber: 0);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.MobilePhone, request.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier, request.PhoneNumber),
                new Claim(ClaimTypes.Name, request.PhoneNumber),
                new Claim(userPassword, request.Password)
            };
            var keyBuffer = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtOptions:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtOptions:Issuer"],
                audience: _configuration["JwtOptions:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(keyBuffer, SecurityAlgorithms.HmacSha256));
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new APIResponse<LoginDTO.Response>(message: "LoginUser: User Login", erorrNumber: 0)
            {
                Data = new LoginDTO.Response()
                {
                    Token = tokenAsString,
                    ExpireDate = token.ValidTo,
                }
            };
        }
    }
}

