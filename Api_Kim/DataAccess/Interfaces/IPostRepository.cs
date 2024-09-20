using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        Task<IEnumerable<Post>> GetRecentPostsAsync();
        Task<IEnumerable<Post>> GetAllAsync(); // Получить все посты
        Task<Post> GetByIdAsync(int id); // Получить пост по ID
        Task CreateAsync(Post post); // Создать пост
        void Delete(Post post); // Удалить пост
    }
}
