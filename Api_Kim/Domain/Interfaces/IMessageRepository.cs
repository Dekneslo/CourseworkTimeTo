using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<List<Message>> GetMessagesByUserAsync(int userId); // Получить сообщения по ID пользователя
        Task SendMessageAsync(Message message); // Отправить сообщение
    }
}
