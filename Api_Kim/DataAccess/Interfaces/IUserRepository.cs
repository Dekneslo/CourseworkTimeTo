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
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
        Task<User> GetByIdAsync(int id); // Получить пользователя по ID
        Task<IEnumerable<User>> GetAllAsync(); // Получить всех пользователей
        Task CreateAsync(User user); // Создать пользователя
        void Delete(User user); // Удалить пользователя
    }
}
