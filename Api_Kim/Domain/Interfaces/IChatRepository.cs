using Domain.Contracts.ChatContracts;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChatRepository : IRepositoryBase<ChatRoom>
    {
        Task CreateChatRoomAsync(CreateChatRoomRequest request);
        Task AddUserToChatAsync(AddUserToChatRequest request);
        Task RemoveUserFromChatAsync(RemoveUserFromChatRequest request);
        Task DeleteChatRoomAsync(int chatRoomId);
        Task CreatePrivateChatAsync(CreateChatRoomRequest request);
        Task<ChatRoom> GetChatRoomByIdAsync(int chatRoomId);
        Task<User> GetUserByIdAsync(int userId);
        Task AddUserToChatRoomAsync(ChatRoomUser chatRoomUser);
        Task<ChatRoomUser> GetChatRoomUserAsync(int chatRoomId, int userId);
        void RemoveUserFromChatRoom(ChatRoomUser chatRoomUser);
        Task SaveChangesAsync();
    }
}
