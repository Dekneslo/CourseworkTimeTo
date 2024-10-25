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
                .Include(c => c.IdUsers)
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
            var chatRoom = await GetChatRoomByIdAsync(request.ChatRoomId);
            var user = await GetUserByIdAsync(request.UserId);
            if (chatRoom != null && user != null)
            {
                chatRoom.IdUsers.Add(user);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            var chatRoom = await GetChatRoomByIdAsync(request.ChatRoomId);
            var user = chatRoom?.IdUsers.FirstOrDefault(u => u.IdUser == request.UserId);

            if (chatRoom != null && user != null)
            {
                chatRoom.IdUsers.Remove(user);
                await SaveChangesAsync();
            }
        }
    }
}

