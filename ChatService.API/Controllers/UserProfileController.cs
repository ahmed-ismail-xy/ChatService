using AutoMapper;
using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CloudChatService.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpPost("UpdateUserInfo")]
        public async Task<ActionResult<UpdateUserInfoDTO.Response>> UpdateUserInfo([FromBody] UpdateUserInfoDTO.Request request)
        {
            UpdateUserInfoDTO.Response response = new UpdateUserInfoDTO.Response();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }

            response = await _userProfileService.UpdateUserInfo(phoneNumber, request);
            return Ok(response);
        }
        [HttpGet("GetUserData")]
        public async Task<IActionResult> GetUserData()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            var result = await _userProfileService.GetUserData(phoneNumber: phoneNumber);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("UpdateUserProfileImage")]
        public async Task<IActionResult> UpdateUserProfileImagee([FromForm] IFormFile userProfileImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            var result = await _userProfileService.UpdateUserImageAsync(phoneNumber, file: userProfileImage);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        //[HttpPut("UpdateUserName")]
        //public async Task<IActionResult> UpdateUserName([FromBody] UserNameDTO userNameDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
        //    var result = await _userProfileService.UpdateUserNameAsync(phoneNumber: phoneNumber, userNameDTO: userNameDTO);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
        //[HttpPut("UpdateUserBio")]
        //public async Task<IActionResult> UpdateUserBio([FromBody] string userBio)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
        //    var result = await _userProfileService.UpdateUserBioAsync(phoneNumber: phoneNumber, userBio: userBio);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
        //[HttpPut("UpdateUserPassword")]
        //public async Task<IActionResult> UpdateUserPassword([FromBody] string userPassord)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
        //    var result = await _userProfileService.UpdateUserPasswordAsync(phoneNumber: phoneNumber, userPassord);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
        //[HttpDelete("DeleteAccountUser")]
        //public async Task<IActionResult> DeleteUserAccount()
        //{
        //    //if (!ModelState.IsValid)
        //    //    return BadRequest(ModelState);
        //    //var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);

        //    //var result = await _userProfileService.DeleteUserAsync(phoneNumber: phoneNumber);

        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //if (result.Success)
        //    //{
        //    //    return Ok(result);
        //    //}

        //    return BadRequest();
        //}

        [HttpDelete("DeleteUserProfileImage")]
        public async Task<IActionResult> DeleteUserProfileImage()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            var result = await _userProfileService.DeleteUserImageAsync(phoneNumber);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //[HttpGet("GetUser")]
        //public async Task<IActionResult> GetUser()
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
        //    var result = await _userProfileService.UpdateUserBioAsync(phoneNumber, userBio: "");
        //    //DataTable data = result.Data;
        //    //List<UserInfo> userInfo = _mapper.Map<List<UserInfo>>(data);

        //    //Console.WriteLine(userInfo.Count);


        //        //AutoMapper.Mapper.DynamicMap<IDataReader, List<UserInfo>>(data);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        [HttpGet("GetUserImage")]
        public async Task<ActionResult> GetUserImage()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            //var result = await _userProfileService.GetUserImageAsync(phoneNumber: phoneNumber);
            var result = await _userProfileService.GetUserImageAsync(phoneNumber: phoneNumber);



            return Ok(result);

            //return File(result.Data.name, "image/jpg", result.Data.name);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (result.Success)
            //{
            //    return Ok(result);
            //}

            //return BadRequest(result);
        }

    }
}
