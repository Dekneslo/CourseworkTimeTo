using BusinessLogic.Interfaces;
using BusinessLogic.Results;
using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _repositoryWrapper.User.GetAllAsync();
            return users.Select(u => new UserDTO
            {
                IdUser = u.IdUser,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.RoleNavigation.NameRole
            }).ToList();
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.RoleNavigation.NameRole
            };
        }

        public async Task<List<UserDTO>> GetUsersByRoleAsync(string role)
        {
            var users = await _repositoryWrapper.User.GetUsersByRoleAsync(role);
            return users.Select(u => new UserDTO
            {
                IdUser = u.IdUser,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.RoleNavigation.NameRole
            }).ToList();
        }

        public async Task<ServiceResult> RegisterUserAsync(RegisterUserDTO userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password 
            };

            await _repositoryWrapper.User.CreateAsync(user);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("User registered successfully", user);
        }

        public async Task<ServiceResult> DeleteUserAsync(int id)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResult.ErrorResult("User not found");
            }

            _repositoryWrapper.User.Delete(user);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("User deleted successfully");
        }
    }
}
