using Domain.Contracts.PostContracts;
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
        }

        public async Task UpdateAsync(Post post)
        {
            await UpdateAsync(post);
        }

        public async Task DeleteAsync(Post post)
        {
            await DeleteAsync(post);
        }

        // Лайк поста
        public async Task LikePostAsync(int postId, int userId)
        {
            var like = new LikesToPost
            {
                IdPost = postId,
                IdUser = userId
            };

            await RepositoryContext.LikesToPosts.AddAsync(like);
        }

        public async Task AddMediaToPostAsync(AddMediaToPostRequest request)
        {
            var postMedia = new PostMedium
            {
                IdPost = request.PostId,
                IdFile = request.FileId
            };
            await RepositoryContext.PostMedia.AddAsync(postMedia);
            await RepositoryContext.SaveChangesAsync();
        }

    }
}
