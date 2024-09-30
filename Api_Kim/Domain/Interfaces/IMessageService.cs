using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Results;

namespace Domain.Interfaces
{
    public interface IMessageService
    {
        Task<ServiceResult> GetMessagesByUserAsync(int userId);  // Получить сообщения по пользователю
        Task<ServiceResult> SendMessageAsync(MessageDTO messageDto); // Отправить сообщение
    }
}
