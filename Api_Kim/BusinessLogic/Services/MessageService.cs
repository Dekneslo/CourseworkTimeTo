using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Results;
using Domain.DTO;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class MessageService : Domain.Interfaces.IMessageService
    {
        private readonly IRepositoryWrapper _repository;

        public MessageService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> GetMessagesByUserAsync(int userId)
        {
            var messages = await _repository.Message.GetMessagesByUserAsync(userId);
            if (messages == null || !messages.Any())
            {
                return ServiceResult.ErrorResult("Сообщений для этого пользователя не найдено");
            }

            var messageDtos = messages.Select(m => new MessageDTO
            {
                IdMessage = m.IdMessage,
                IdSender = m.IdSender ?? 0,
                IdRecipient = m.IdRecipient ?? 0,
                MessageText = m.MessageText,
                SendingDatetime = m.SendingDatetime ?? DateTime.Now
            }).ToList();

            return ServiceResult.SuccessResult("Сообщения успешно получены", messageDtos);
        }

        public async Task<MessageDTO> CreateMessageDTOAsync(Message message)
        {
            return new MessageDTO
            {
                IdMessage = message.IdMessage,
                IdSender = message.IdSender ?? 0, // Приведение int?
                IdRecipient = message.IdRecipient ?? 0, // Приведение int?
                MessageText = message.MessageText,
                SendingDatetime = message.SendingDatetime ?? DateTime.Now // Приведение DateTime?
            };
        }

        public async Task<ServiceResult> SendMessageAsync(MessageDTO messageDto)
        {
            var message = new Message
            {
                IdSender = messageDto.IdSender,
                IdRecipient = messageDto.IdRecipient,
                MessageText = messageDto.MessageText,
                SendingDatetime = DateTime.Now
            };

            await _repository.Message.SendMessageAsync(message);

            return ServiceResult.SuccessResult("Сообщения успешно отправлены", message);
        }
    }
}
