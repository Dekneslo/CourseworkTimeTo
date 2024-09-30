using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;  
using Domain.DTO;           


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

        /// <summary>
        /// ��������� ��������� ������������
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     GET /api/Message/1
        ///
        /// </remarks>
        /// <param name="userId">ID ������������</param>
        /// <returns>������ ��������� ������������</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesByUser(int userId)
        {
            var messages = await _messageService.GetMessagesByUserAsync(userId);
            return Ok(messages);
        }

        /// <summary>
        /// �������� ������ ���������
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     POST /api/Message
        ///     {
        ///        "IdSender": 1,
        ///        "IdRecipient": 2,
        ///        "MessageText": "������, ��� ����?"
        ///     }
        ///
        /// </remarks>
        /// <param name="messageDto">������ ���������</param>
        /// <returns>��������� ��������</returns>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDTO messageDto)
        {
            await _messageService.SendMessageAsync(messageDto);
            return Ok();
        }
    }
}