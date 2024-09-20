using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Results;

namespace BusinessLogic.Interfaces
{
    public interface IMessageService
    {
        Task<ServiceResult> GetMessagesByUserAsync(int userId);  // Получить сообщения по пользователю
        Task<ServiceResult> SendMessageAsync(MessageDTO messageDto); // Отправить сообщение
    }
}
