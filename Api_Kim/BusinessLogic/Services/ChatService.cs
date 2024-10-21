using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Domain.Models;
using Domain.Results;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<ServiceResult> CreateChatRoomAsync(CreateChatRoomRequest request)
        {
            await _chatRepository.CreateChatRoomAsync(request);
            return ServiceResult.SuccessResult("Чат-комната успешно создана");
        }

        public async Task<ServiceResult> AddUserToChatAsync(AddUserToChatRequest request)
        {
            await _chatRepository.AddUserToChatAsync(request);
            return ServiceResult.SuccessResult("Пользователь успешно добавлен в чат");
        }

        public async Task<ServiceResult> RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            await _chatRepository.RemoveUserFromChatAsync(request);
            return ServiceResult.SuccessResult("Пользователь успешно удален из чата");
        }

        public async Task<ServiceResult> DeleteChatRoomAsync(int chatRoomId)
        {
            await _chatRepository.DeleteChatRoomAsync(chatRoomId);
            return ServiceResult.SuccessResult("Чат-комната успешно удалена");
        }

        // Метод для создания обычного чата (один-на-один)
        public async Task<ServiceResult> CreatePrivateChatAsync(CreateChatRoomRequest request)
        {
            await _chatRepository.CreatePrivateChatAsync(request);
            return ServiceResult.SuccessResult("Приватный чат успешно создан");
        }
    }
}
