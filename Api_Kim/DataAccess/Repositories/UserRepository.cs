using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await RepositoryContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await RepositoryContext.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task GrantAccessToCourseAsync(int userId, int courseId)
        {
            var userCourse = new UserCourse
            {
                UserId = userId,
                CourseId = courseId,
                AccessGranted = DateTime.Now
            };
            await RepositoryContext.UserCourses.AddAsync(userCourse);
        }

        public async Task<IEnumerable<Course>> GetCoursesByUserAsync(int userId)
        {
            return await RepositoryContext.UserCourses
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Course)
                .ToListAsync();
        }
        //public UserRepository(CharityDBContext repositoryContext) : base(repositoryContext)
        //{

        //}
        //public async Task<User> GetByEmailAsync(string email)
        //{
        //    return await RepositoryContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        //}




        //public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        //{
        //    return await RepositoryContext.Set<User>().Where(u => u.Role == role).ToListAsync();
        //}

        //public async Task GrantAccessToCourseAsync(int userId, int courseId)
        //{
        //    var userCourse = new UserCourse { UserId = userId, CourseId = courseId };
        //    await RepositoryContext.Set<UserCourse>().AddAsync(userCourse);
        //    await RepositoryContext.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Course>> GetCoursesByUserAsync(int userId)
        //{
        //    return await RepositoryContext.Set<UserCourse>()
        //        .Where(uc => uc.UserId == userId)
        //        .Select(uc => uc.Course)
        //        .ToListAsync();
        //}



    }
}
