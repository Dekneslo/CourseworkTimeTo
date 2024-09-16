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
        Task<Course> GetCourseDetailsAsync(int courseId); // Получение деталей курса
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category); // Получение курсов по категории


        //Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category); // Получение курсов по категории
        //Task<IEnumerable<Course>> GetPopularCoursesAsync(); // Получение популярных курсов
        //Task<IEnumerable<Course>> GetCoursesByUserAsync(int userId); // Получение курсов, доступных пользователю
        ////Task AttachFileToCourseAsync(int courseId, File file); // Присоединение файла к курсу
    }

}
