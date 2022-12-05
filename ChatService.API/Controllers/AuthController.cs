using AutoMapper;
using CloudChatService.Core.DTOs.Auth;
using CloudChatService.Core.DTOs.UserAuth;
using CloudChatService.Core.Services;
using CloudChatService.Infrastrucure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CloudChatService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IMapper _mapper;

        public AuthController(IUserAuthService userAuthService, IMapper mapper)
        {
            _userAuthService = userAuthService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync([FromForm] RegisterDTO.Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newUserInfo = _mapper.Map<UserInfo>(request);
            var result = await _userAuthService.RegisterUserAsync(userInfo: newUserInfo, userImage: request.UserImage);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("ELSE BAD : " + result.Message);
            }
        }
     
        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync([FromForm] LoginDTO.Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userAuthService.LoginUserAsync(request);
            if (result.Success)
                return Ok(result);

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

    }
}
