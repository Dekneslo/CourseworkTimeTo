using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<List<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task<List<Course>> GetAllAsync(); // Получить все курсы
        Task<Course> GetByIdAsync(int id); // Получить курс по ID
        Task CreateAsync(Course course); 
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);
        Task LikeCourseAsync(int courseId, int userId);
        Task AddCommentAsync(int courseId, Comment comment);
    }
}
