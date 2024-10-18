using Domain.Interfaces;
using Domain.Results;
using Domain.Contracts.UserContracts;
using Domain.Models1;
using Domain.Wrapper;
using Mapster;

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
            return users.Adapt<List<GetUserResponse>>();
        }

        public async Task<GetUserResponse> GetUserByIdAsync(int id)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(id);
            if (user == null) return null;

            return user.Adapt<GetUserResponse>();
        }

        public async Task<List<GetUserResponse>> GetUsersByRoleAsync(string role)
        {
            var users = await _repositoryWrapper.User.GetUsersByRoleAsync(role);
            return users.Adapt<List<GetUserResponse>>();
        }

        public async Task<ServiceResult> RegisterUserAsync(CreateUserRequest request)
        {
            if (await _repositoryWrapper.User.GetUserByEmailAsync(request.Email) != null)
            {
                return ServiceResult.ErrorResult("Пользователь с таким email уже существует");
            }
            var user = request.Adapt<User>();

            await _repositoryWrapper.User.CreateAsync(user);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Пользователь успешно зарегистрирован", user);
        }

        public async Task<ServiceResult> CreateUserAsync(CreateUserRequest request)
        {
            var user = request.Adapt<User>();

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

            request.Adapt(user);

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
