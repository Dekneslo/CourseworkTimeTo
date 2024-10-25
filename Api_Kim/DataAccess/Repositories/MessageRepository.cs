using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<Message>> GetMessagesByUserAsync(int userId)
        {
            return await RepositoryContext.Messages
                         .Where(message => message.IdRecipient == userId || message.IdSender == userId)
                         .Include(m => m.IdSenderNavigation)
                         .Include(m => m.IdRecipientNavigation)
                         .ToListAsync();
        }

        public async Task<List<Message>> GetMessagesBetweenUsersAsync(int senderId, int recipientId)
        {
            return await RepositoryContext.Messages
                         .Where(m => (m.IdSender == senderId && m.IdRecipient == recipientId) ||
                                     (m.IdSender == recipientId && m.IdRecipient == senderId))
                         .Include(m => m.IdSenderNavigation)
                         .Include(m => m.IdRecipientNavigation)
                         .ToListAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            await CreateAsync(message);
            await SaveAsync();
        }
    }
}

