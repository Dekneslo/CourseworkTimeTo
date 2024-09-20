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
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Post>> GetRecentPostsAsync()
        {
            return await FindAll().OrderByDescending(post => post.DatePosted).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await FindByCondition(post => post.IdPost == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Post post)
        {
            Create(post);
            await SaveAsync();
        }
    }
}
