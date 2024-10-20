using Domain.Contracts.ChatContracts;
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
    }

}
