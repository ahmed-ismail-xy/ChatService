using AutoMapper;
using CloudChatService.Core.DTOs.Message;
using CloudChatService.Core.Services;
using CloudChatService.Infrastrucure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CloudChatService.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;   
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessageAsync([FromForm] MessageDTO<IFormFile> messageDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            var result = await _messageService.SendMessageAsync(phoneNumber, messageDTO);

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
        [HttpPost("GetAllMessagesbyChatId")]
        public async Task<IActionResult> GetAllMessages([FromForm] int chatId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            var result = await _messageService.GetAllMessagesByChatIdAsync(chatId: chatId);

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
