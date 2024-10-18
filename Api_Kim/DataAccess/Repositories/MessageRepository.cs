﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models1;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(CharityDB1Context repositoryContext) : base(repositoryContext) { }

        public async Task<List<Message>> GetMessagesByUserAsync(int userId)
        {
            return await RepositoryContext.Messages
                         .Where(message => message.IdRecipient == userId || message.IdSender == userId)
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

