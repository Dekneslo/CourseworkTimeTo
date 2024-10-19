using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Results;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Domain.Contracts.MessageContracts;
using Mapster;

namespace BusinessLogic.Services
{
    public class MessageService : IMessageService
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

            var messageResponses = messages.Adapt<List<GetMessageResponse>>();

            return ServiceResult.SuccessResult("Сообщения успешно получены", messageResponses);
        }


        public async Task<ServiceResult> SendMessageAsync(SendMessageRequest messageRequest)
        {
            var message = messageRequest.Adapt<Message>();
            message.SendingDatetime = DateTime.Now;

            await _repository.Message.SendMessageAsync(message);

            return ServiceResult.SuccessResult("Сообщение успешно отправлено", message);
        }
    }
}
