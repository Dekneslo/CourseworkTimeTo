using Domain.Interfaces;
using Domain.Models1;
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

        public async Task<List<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await FindByConditionAsync(course => course.IdCategory == categoryId);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var courses = await FindByConditionAsync(course => course.IdCourse == id);
            return courses.FirstOrDefault();
        }

        public async Task CreateAsync(Course course)
        {
            await CreateAsync(course);
            await SaveAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            await UpdateAsync(course);
            await SaveAsync(); 
        }

        public async Task DeleteAsync(Course course)
        {
            await DeleteAsync(course);
            await SaveAsync();
        }
    }
}
