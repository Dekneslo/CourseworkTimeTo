using BusinessLogic.Interfaces;
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _repositoryWrapper.User.FindAll().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _repositoryWrapper.User
                .FindByCondition(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task RegisterUser(User user)
        {
            _repositoryWrapper.User.Create(user);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateUser(User user)
        {
            _repositoryWrapper.User.Update(user);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                _repositoryWrapper.User.Delete(user);
                await _repositoryWrapper.SaveAsync();
            }
        }

        public async Task ChangeAccessLevel(int id, AccessLevel newAccessLevel)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                user.AccessLevel = newAccessLevel;
                _repositoryWrapper.User.Update(user);
                await _repositoryWrapper.SaveAsync();
            }
        }
        //private IRepositoryWrapper _repositoryWrapper;

        //public UserService(IRepositoryWrapper repositoryWrapper)
        //{
        //    _repositoryWrapper = repositoryWrapper;
        //}

        //public Task<List<User>> GetAll()
        //{
        //    return _repositoryWrapper.User.FindAll().ToListAsync();
        //}

        //public Task<User> GetById(int id)
        //{
        //    var user = _repositoryWrapper.User
        //        .FindByCondition(x => x.IdUser == id).First();
        //    return Task.FromResult(user);
        //}

        //public Task Create(User model)
        //{
        //    _repositoryWrapper.User.Create(model);
        //    _repositoryWrapper.Save();
        //    return Task.CompletedTask;
        //}

        //public Task Update(User model)
        //{
        //    _repositoryWrapper.User.Update(model);
        //    _repositoryWrapper.Save();
        //    return Task.CompletedTask;
        //}

        //public Task Delete(int id)
        //{
        //    var user = _repositoryWrapper.User
        //        .FindByCondition(x => x.IdUser == id).First();

        //    _repositoryWrapper.User.Delete(user);
        //    _repositoryWrapper.Save();
        //    return Task.CompletedTask;
        //}
    }
}
