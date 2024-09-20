using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<IEnumerable<Message>> GetMessagesByUserAsync(int userId); // Получить сообщения по ID пользователя
        Task SendMessageAsync(Message message); // Отправить сообщение
    }
}
