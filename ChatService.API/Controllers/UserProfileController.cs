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
        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
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

        [HttpPost("UpdateProfileImage")]
        public async Task<IActionResult> UpdateProfileImagee([FromForm] IFormFile userProfileImage)
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

        [HttpDelete("DeleteProfileImage")]
        public async Task<IActionResult> DeleteProfileImage()
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

        [HttpGet("GetProfileImage")]
        public async Task<ActionResult> GetProfileImage()
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
