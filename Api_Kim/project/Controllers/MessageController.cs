using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;  
using DataAccess.DTO;           


namespace project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesByUser(int userId)
        {
            var messages = await _messageService.GetMessagesByUserAsync(userId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDTO messageDto)
        {
            await _messageService.SendMessageAsync(messageDto);
            return Ok();
        }
    }
}