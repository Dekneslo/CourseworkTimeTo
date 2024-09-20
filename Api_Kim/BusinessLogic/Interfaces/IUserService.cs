using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.DTO;
using BusinessLogic.Results;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<ServiceResult> RegisterUserAsync(RegisterUserDTO registerDto);
        Task<ServiceResult> DeleteUserAsync(int id);
        Task<List<UserDTO>> GetUsersByRoleAsync(string role);
    }
}
