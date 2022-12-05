using AutoMapper;
using CloudChatService.Core.DTOs.Chat;
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

    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        [HttpGet("GetChats")]
        public async Task<IActionResult> GetAllChats()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            var result = await _chatService.GetAllChatsAsync(phoneNumber: phoneNumber);

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
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            var result = await _chatService.GetAllUsersAsync(phoneNumber: phoneNumber);

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
        
        [HttpPost("IsChatExistAndCreateIt")]
        public async Task<IActionResult> CheckIsChatExistAndCreateIt([FromForm] CheckIsChatExistAndCreateItDTO.Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _chatService.CheckIsChatExistOrCreateItAsync(request);

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