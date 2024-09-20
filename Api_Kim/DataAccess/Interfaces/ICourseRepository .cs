using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task<IEnumerable<Course>> GetAllAsync(); // Получить все курсы
        Task<Course> GetByIdAsync(int id); // Получить курс по ID
        Task CreateAsync(Course course); // Создать курс
        void Delete(Course course); // Удалить курс
    }
}
