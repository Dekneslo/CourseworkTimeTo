using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models1;
using Domain.Results;
using Domain.Contracts.UserContracts;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult> RegisterUserAsync(CreateUserRequest request);
        Task<ServiceResult> DeleteUserAsync(int id);
        Task<List<GetUserResponse>> GetAllUsersAsync();
        Task<GetUserResponse> GetUserByIdAsync(int id);
        Task<ServiceResult> CreateUserAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateUserAsync(int id, UpdateUserRequest request);  
        Task<List<GetUserResponse>> GetUsersByRoleAsync(string role);
    }
}
