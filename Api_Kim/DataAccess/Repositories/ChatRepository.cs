using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ChatRepository : RepositoryBase<ChatRoom>, IChatRepository
    {
        public ChatRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

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
            var chatRoomUser = new ChatRoomUser
            {
                IdChatRoom = request.ChatRoomId,
                IdUser = request.UserId
            };
            await RepositoryContext.ChatRoomUsers.AddAsync(chatRoomUser);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            var chatRoomUser = await RepositoryContext.ChatRoomUsers
                .FirstOrDefaultAsync(c => c.IdChatRoom == request.ChatRoomId && c.IdUser == request.UserId);

            if (chatRoomUser != null)
            {
                RepositoryContext.ChatRoomUsers.Remove(chatRoomUser);
                await RepositoryContext.SaveChangesAsync();
            }
        }

        public async Task DeleteChatRoomAsync(int chatRoomId)
        {
            var chatRoom = await RepositoryContext.ChatRooms
                .FirstOrDefaultAsync(c => c.IdChatRoom == chatRoomId);

            if (chatRoom != null)
            {
                RepositoryContext.ChatRooms.Remove(chatRoom);
                await RepositoryContext.SaveChangesAsync();
            }
        }

        // Создание приватного чата (один-на-один)
        public async Task CreatePrivateChatAsync(CreateChatRoomRequest request)
        {
            var privateChat = new ChatRoom
            {
                NameRoom = request.ChatRoomName
            };
            await RepositoryContext.ChatRooms.AddAsync(privateChat);
            await RepositoryContext.SaveChangesAsync();
        }
    }
}

