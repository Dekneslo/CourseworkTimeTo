using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Domain.Models;
using Domain.Results;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Domain.Wrapper;

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
            var chatRoom = await _chatRepository.GetChatRoomByIdAsync(request.ChatRoomId);

            if (chatRoom == null)
            {
                return new ServiceResult { Success = false, Errors = new List<string> { "Чат-комната не найдена" } };
            }

            var user = await _chatRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                return new ServiceResult { Success = false, Errors = new List<string> { "Пользователь не найден" } };
            }

            chatRoom.IdUsers.Add(user); // Добавляем пользователя в чат-комнату
            await _chatRepository.SaveChangesAsync(); // Сохраняем изменения

            return new ServiceResult { Success = true, Data = "Пользователь добавлен" };
        }

        public async Task<ServiceResult> RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            var chatRoom = await _chatRepository.GetChatRoomByIdAsync(request.ChatRoomId);

            if (chatRoom == null)
            {
                return new ServiceResult { Success = false, Errors = new List<string> { "Чат-комната не найдена" } };
            }

            var user = chatRoom.IdUsers.FirstOrDefault(u => u.IdUser == request.UserId);
            if (user == null)
            {
                return new ServiceResult { Success = false, Errors = new List<string> { "Пользователь не найден в этой чат-комнате" } };
            }

            chatRoom.IdUsers.Remove(user); // Удаляем пользователя из чат-комнаты
            await _chatRepository.SaveChangesAsync(); // Сохраняем изменения

            return new ServiceResult { Success = true, Data = "Пользователь удален" };
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
