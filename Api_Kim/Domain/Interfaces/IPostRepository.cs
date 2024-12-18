﻿using Domain.Contracts.PostContracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        Task<List<Post>> GetRecentPostsAsync();
        Task<List<Post>> GetAllAsync(); // Получить все посты
        Task<Post> GetByIdAsync(int id); // Получить пост по ID
        Task CreateAsync(Post post); 
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
        Task LikePostAsync(int postId, int userId);
        Task AddMediaToPostAsync(AddMediaToPostRequest request);
    }
}
