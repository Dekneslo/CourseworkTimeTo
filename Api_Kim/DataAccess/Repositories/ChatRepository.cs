using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ChatRepository : RepositoryBase<Chat>, IChatRepository
    {
        public async Task CreateChatRoomAsync(CreateChatRoomRequest request)
        {
            var chatRoom = new ChatRoom
            {
                NameRoom = request.ChatRoomName
            };
            await RepositoryContext.ChatRooms.AddAsync(chatRoom);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task AddUserToChatAsync(AddUserToChatRequest request)
        {
            var chatRoomUser = new ChatRoom
            {
                IdChatRoom = request.ChatRoomId,
                IdUser = request.UserId
            };
            await RepositoryContext.ChatRoom.AddAsync(chatRoomUser);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            var chatRoomUser = await RepositoryContext.ChatRoom
                .FirstOrDefaultAsync(c => c.IdChatRoom == request.ChatRoomId && c.IdUser == request.UserId);

            if (chatRoomUser != null)
            {
                RepositoryContext.ChatRoom.Remove(chatRoomUser);
                await RepositoryContext.SaveChangesAsync();
            }
        }

    }
}
