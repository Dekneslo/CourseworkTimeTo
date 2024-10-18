using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models1;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetUsersByRoleAsync(string role);
        Task<User> GetByIdAsync(int id); // Получить пользователя по ID
        Task<List<User>> GetAllAsync(); // Получить всех пользователей
        Task CreateAsync(User user); // Создать пользователя
        Task DeleteAsync(User user); // Удалить пользователя
    }
}
