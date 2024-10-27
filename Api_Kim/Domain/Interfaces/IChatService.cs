using Domain.Contracts.ChatContracts;
using Domain.Models;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChatService
    {
        Task<ServiceResult> CreateChatRoomAsync(CreateChatRoomRequest request);
        Task<ServiceResult> AddUserToChatAsync(AddUserToChatRequest request);
        Task<ServiceResult> RemoveUserFromChatAsync(RemoveUserFromChatRequest request);
        Task<ServiceResult> CreatePrivateChatAsync(CreateChatRoomRequest request);
        Task<ServiceResult> DeleteChatRoomAsync(int chatRoomId);
        Task AddUserToChatRoomAsync(ChatRoomUser chatRoomUser); 
        Task<ChatRoomUser> GetChatRoomUserAsync(int chatRoomId, int userId); 
        void RemoveUserFromChatRoom(ChatRoomUser chatRoomUser); 
    }
}
