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
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<Post>> GetRecentPostsAsync()
        {
            var posts = await FindAllAsync();
            return posts.OrderByDescending(post => post.DatePosted)
                        .Take(10)
                        .ToList();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var posts = await FindByConditionAsync(post => post.IdPost == id);
            return posts.FirstOrDefault();
        }

        public async Task CreateAsync(Post post)
        {
            await CreateAsync(post);
            await SaveAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            await UpdateAsync(post);
            await SaveAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            await DeleteAsync(post);
            await SaveAsync();
        }

    }
}
