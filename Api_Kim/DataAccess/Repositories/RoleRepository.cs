using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await FindByCondition(role => role.IdRole == id).FirstOrDefaultAsync();
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await FindAllAsync();
        }
    }
}
