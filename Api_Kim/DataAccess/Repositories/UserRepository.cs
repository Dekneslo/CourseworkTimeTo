using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models1;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CharityDB1Context repositoryContext) : base(repositoryContext) { }

        public async Task<List<User>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var users = await FindByConditionAsync(user => user.IdUser == id);
            return users.FirstOrDefault();
        }

        public async Task CreateAsync(User user)
        {
            CreateAsync(user);
            await SaveAsync();
        }

        public async Task UpdateAsync(User user)
        {
            UpdateAsync(user); 
            await SaveAsync();  
        }

        public async Task DeleteAsync(User user)
        {
            DeleteAsync(user);  
            await SaveAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return FindByConditionAsync(user => user.Email == email).ContinueWith(task => task.Result.FirstOrDefault());
        }

        public async Task<List<User>> GetUsersByRoleAsync(string role)
        {
            return await FindByConditionAsync(user => user.RoleNavigation.NameRole == role);
        }
    }
}
