using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await FindByCondition(user => user.IdUser == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user)
        {
            Create(user);
            await SaveAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return FindByCondition(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await FindByCondition(user => user.RoleNavigation.NameRole == role).ToListAsync();
        }
    }
}
