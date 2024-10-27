using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ChatRepository : RepositoryBase<ChatRoom>, IChatRepository /*ChatRepository : IChatRepository*/
    {
        private readonly CharityDBContext _context;

        public ChatRepository(CharityDBContext context) : base(context)
        {
            _context = context;
        }
        //public ChatRepository(CharityDBContext context)
        //{
        //    _context = context;
        //}

        public async Task CreateChatRoomAsync(CreateChatRoomRequest request)
        {
            var chatRoom = new ChatRoom
            {
                NameRoom = request.ChatRoomName
            };
            await _context.ChatRooms.AddAsync(chatRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<ChatRoom> GetChatRoomByIdAsync(int chatRoomId)
        {
            return await _context.ChatRooms
                .Include(c => c.ChatRoomUsers)
                .FirstOrDefaultAsync(c => c.IdChatRoom == chatRoomId);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChatRoomAsync(int chatRoomId)
        {
            var chatRoom = await GetChatRoomByIdAsync(chatRoomId);
            if (chatRoom != null)
            {
                _context.ChatRooms.Remove(chatRoom);
                await SaveChangesAsync();
            }
        }

        public async Task CreatePrivateChatAsync(CreateChatRoomRequest request)
        {
            var privateChat = new ChatRoom
            {
                NameRoom = request.ChatRoomName
            };
            await _context.ChatRooms.AddAsync(privateChat);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserToChatAsync(AddUserToChatRequest request)
        {
            var chatRoomUser = new ChatRoomUser
            {
                IdChatRoom = request.ChatRoomId,
                IdUser = request.UserId
            };

            await _context.ChatRoomUsers.AddAsync(chatRoomUser);
            await SaveChangesAsync();
        }

        public async Task RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            var chatRoomUser = await _context.ChatRoomUsers
                .FirstOrDefaultAsync(cru => cru.IdChatRoom == request.ChatRoomId && cru.IdUser == request.UserId); // Исправлено

            if (chatRoomUser != null)
            {
                _context.ChatRoomUsers.Remove(chatRoomUser);
                await SaveChangesAsync();
            }
        }

        public async Task AddUserToChatRoomAsync(ChatRoomUser chatRoomUser)
        {
            await _context.ChatRoomUsers.AddAsync(chatRoomUser);
        }

        public async Task<ChatRoomUser> GetChatRoomUserAsync(int chatRoomId, int userId)
        {
            return await _context.ChatRoomUsers
                .FirstOrDefaultAsync(cru => cru.IdChatRoom == chatRoomId && cru.IdUser == userId); // Исправлено
        }

        public void RemoveUserFromChatRoom(ChatRoomUser chatRoomUser)
        {
            _context.ChatRoomUsers.Remove(chatRoomUser);
        }

    }
}

