using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Contracts.MessageContracts;

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
        /// Получение сообщений пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/Message/1
        ///
        /// </remarks>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Список сообщений пользователя</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesByUser(int userId)
        {
            var messages = await _messageService.GetMessagesByUserAsync(userId);
            return Ok(messages);
        }

        /// <summary>
        /// Отправка нового сообщения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Message
        ///     {
        ///        "IdSender": 1,
        ///        "IdRecipient": 2,
        ///        "MessageText": "Привет, как дела?"
        ///     }
        ///
        /// </remarks>
        /// <param name="messageDto">Модель сообщения</param>
        /// <returns>Результат операции</returns>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest messageRequest)
        {
            await _messageService.SendMessageAsync(messageRequest);
            return Ok();
        }
        //Подумать надо ли??
        /// <summary>
        /// Получить все сообщения между двумя пользователями
        /// </summary>
        /// <param name="senderId">ID отправителя</param>
        /// <param name="recipientId">ID получателя</param>
        /// <returns>Список сообщений</returns>
        [HttpGet("{senderId}/to/{recipientId}")]
        public async Task<IActionResult> GetMessagesBetweenUsers(int senderId, int recipientId)
        {
            var messages = await _messageService.GetMessagesBetweenUsersAsync(senderId, recipientId);
            return Ok(messages);
        }
    }
}