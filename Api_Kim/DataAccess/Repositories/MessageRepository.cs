using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Message>> GetMessagesByUserAsync(int userId)
        {
            return await FindByCondition(message => message.IdRecipient == userId || message.IdSender == userId)
                         .Include(m => m.IdSenderNavigation)
                         .Include(m => m.IdRecipientNavigation)
                         .ToListAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            Create(message);
            await SaveAsync();
        }
    }
}

