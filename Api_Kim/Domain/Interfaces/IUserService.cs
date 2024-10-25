using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Results;
using Domain.Contracts.UserContracts;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetAllUsersAsync();
        Task<GetUserResponse> GetUserByIdAsync(int id);  
        Task<List<GetUserResponse>> GetUsersByRoleAsync(string role);
        Task<ServiceResult> RegisterUserAsync(CreateUserRequest request);
        Task<ServiceResult> CreateUserAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateUserAsync(int id, UpdateUserRequest request);
        Task<ServiceResult> DeleteUserAsync(int id);
        Task<ServiceResult> ChangeUserLanguageAsync(int userId, string languageCode);  // Смена языка пользователя
        Task<ServiceResult> ChangeUserPasswordAsync(ChangeUserPasswordRequest request);
    }
}
