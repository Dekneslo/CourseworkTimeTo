using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Results;
using Domain.Contracts.MessageContracts;

namespace Domain.Interfaces
{
    public interface IMessageService
    {
        Task<ServiceResult> GetMessagesByUserAsync(int userId);  // Получить сообщения по пользователю
        Task<ServiceResult> SendMessageAsync(SendMessageRequest messageRequest); // Отправить сообщение
    }
}
