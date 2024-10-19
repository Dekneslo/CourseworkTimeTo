using Domain.Interfaces;
using Domain.Models;
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

        // Реализация метода для лайков курса
        public async Task LikeCourseAsync(int courseId, int userId)
        {
            var like = new LikesToCourse
            {
                IdCourse = courseId,
                IdUser = userId
            };

            await RepositoryContext.LikesToCourses.AddAsync(like);
            await SaveAsync();
        }

        // Реализация метода для добавления комментария к курсу
        public async Task AddCommentAsync(int courseId, Comment comment)
        {
            comment.IdCourse = courseId;
            await RepositoryContext.Comments.AddAsync(comment);
            await SaveAsync();
        }
    }
}
