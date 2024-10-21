using Domain.Contracts.ChatContracts;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChatRepository
    {
        Task CreateChatRoomAsync(CreateChatRoomRequest request);
        Task AddUserToChatAsync(AddUserToChatRequest request);
        Task RemoveUserFromChatAsync(RemoveUserFromChatRequest request);
        Task DeleteChatRoomAsync(int chatRoomId);
        Task CreatePrivateChatAsync(CreateChatRoomRequest request);
    }
}
