using Domain.Interfaces;
using Domain.Results;
//using Domain.DTO;
using Domain.Contracts.UserContracts;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GetUserResponse>> GetAllUsersAsync()
        {
            var users = await _repositoryWrapper.User.GetAllAsync();
            return users.Select(u => new GetUserResponse
            {
                IdUser = u.IdUser,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.RoleNavigation.NameRole
            }).ToList();
        }

        public async Task<GetUserResponse> GetUserByIdAsync(int id)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(id);
            if (user == null) return null;

            return new GetUserResponse
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.RoleNavigation.NameRole
            };
        }

        public async Task<List<GetUserResponse>> GetUsersByRoleAsync(string role)
        {
            var users = await _repositoryWrapper.User.GetUsersByRoleAsync(role);
            return users.Select(u => new GetUserResponse
            {
                IdUser = u.IdUser,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.RoleNavigation.NameRole
            }).ToList();
        }

        //public async Task<ServiceResult> RegisterUserAsync(RegisterUserDTO userDto)
        //{
        //    var user = new User
        //    {
        //        FirstName = userDto.FirstName,
        //        LastName = userDto.LastName,
        //        Email = userDto.Email,
        //        Password = userDto.Password 
        //    };

        //    await _repositoryWrapper.User.CreateAsync(user);
        //    await _repositoryWrapper.SaveAsync();
        //    return ServiceResult.SuccessResult("Пользователь успешно зарегистрирован", user);
        //}
        public async Task<ServiceResult> RegisterUserAsync(CreateUserRequest request)
        {
            if (await _repositoryWrapper.User.GetUserByEmailAsync(request.Email) != null)
            {
                return ServiceResult.ErrorResult("Пользователь с таким email уже существует");
            }
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password 
            };

            await _repositoryWrapper.User.CreateAsync(user);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Пользователь успешно зарегистрирован", user);
        }

        public async Task<ServiceResult> CreateUserAsync(CreateUserRequest request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            await _repositoryWrapper.User.CreateAsync(user);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Пользователь успешно создан", user);
        }


        public async Task<ServiceResult> UpdateUserAsync(int id, UpdateUserRequest request)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResult.ErrorResult("Пользователь не найден");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            await _repositoryWrapper.User.UpdateAsync(user);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Пользователь успешно обновлен", user);
        }



        public async Task<ServiceResult> DeleteUserAsync(int id)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResult.ErrorResult("Пользователь не найден");
            }

            await _repositoryWrapper.User.DeleteAsync(user);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Пользователь успешно удален");
        }
    }
}
