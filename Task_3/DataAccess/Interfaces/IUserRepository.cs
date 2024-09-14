using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmailAsync(string email); // Получение пользователя по email
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role); // Получение пользователей по роли (например, клиенты или сотрудники)
        Task GrantAccessToCourseAsync(int userId, int courseId); // Предоставление пользователю доступа к курсу
        Task<IEnumerable<Course>> GetCoursesByUserAsync(int userId); // Получение курсов, доступных пользователю
    }
}
