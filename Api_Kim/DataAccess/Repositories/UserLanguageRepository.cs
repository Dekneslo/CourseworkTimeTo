using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserLanguageRepository : RepositoryBase<UserLanguage>, IUserLanguageRepository
    {
        public UserLanguageRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<UserLanguage> GetByUserIdAsync(int userId)
        {
            return await FindByCondition(ul => ul.IdUser == userId)
                         .FirstOrDefaultAsync();
        }
    }
}
