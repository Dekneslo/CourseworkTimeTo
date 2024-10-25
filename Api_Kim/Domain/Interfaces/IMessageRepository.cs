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
        Task<List<Message>> GetMessagesByUserAsync(int userId);
        Task<List<Message>> GetMessagesBetweenUsersAsync(int senderId, int recipientId); // Новый метод
        Task SendMessageAsync(Message message);
    }
}
