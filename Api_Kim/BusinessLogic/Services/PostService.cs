using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Results;
using Domain.Wrapper;
using Domain.Contracts.PostContracts;

namespace BusinessLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IRepositoryWrapper _repository;

        public PostService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // Получение всех постов
        public async Task<IEnumerable<GetPostResponse>> GetAllPostsAsync()
        {
            var posts = await _repository.Post.GetAllAsync();
            return posts.Select(p => new GetPostResponse
            {
                IdPost = p.IdPost,
                PostTitle = p.PostTitle,
                PostContent = p.PostContent,
                DatePosted = p.DatePosted
            });
        }

        // Создание поста
        public async Task<ServiceResult> CreatePostAsync(CreatePostRequest postRequest)
        {
            var post = new Post
            {
                PostTitle = postRequest.PostTitle,
                PostContent = postRequest.PostContent,
                DatePosted = postRequest.DatePosted ?? DateTime.Now, // Присваиваем текущую дату, если DatePosted == null
                IdUser = postRequest.IdUser
            };

            await _repository.Post.CreateAsync(post);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Пост успешно создан", post);
        }


        // Обновление поста
        public async Task<ServiceResult> UpdatePostAsync(UpdatePostRequest request)
        {
            var post = await _repository.Post.GetByIdAsync(request.IdPost);
            if (post == null)
            {
                return ServiceResult.ErrorResult("Пост не найден");
            }

            post.PostTitle = request.PostTitle;
            post.PostContent = request.PostContent;
            await _repository.Post.UpdateAsync(post);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Пост успешно обновлен", post);
        }

        // Удаление поста
        public async Task<ServiceResult> DeletePostAsync(int id)
        {
            var post = await _repository.Post.GetByIdAsync(id);
            if (post == null)
            {
                return ServiceResult.ErrorResult("Пост не найден");
            }

            await _repository.Post.DeleteAsync(post);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Пост успешно удален");
        }
    }
}
