using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await FindByCondition(course => course.IdCategory == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await FindByCondition(course => course.IdCourse == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Course course)
        {
            Create(course);
            await SaveAsync();
        }

        public void Delete(Course course)
        {
            Delete(course);
        }
    }
}
