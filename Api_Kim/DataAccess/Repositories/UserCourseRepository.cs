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
    public class UserCourseRepository : RepositoryBase<UsersCourse>, IUserCourseRepository
    {
        public UserCourseRepository(CharityDBContext context) : base(context) { }

        public async Task<UsersCourse> GetByCourseAndUserAsync(int courseId, int userId)
        {
            return await FindByCondition(uc => uc.IdCourse == courseId && uc.IdUser == userId)
                         .FirstOrDefaultAsync();
        }
    }
}
