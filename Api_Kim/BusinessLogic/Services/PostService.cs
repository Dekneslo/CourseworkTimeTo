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
using Mapster;

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
            return posts.Adapt<List<GetPostResponse>>();
        }

        // Создание поста
        public async Task<ServiceResult> CreatePostAsync(CreatePostRequest postRequest)
        {
            var post = postRequest.Adapt<Post>();
            post.DatePosted = postRequest.DatePosted ?? DateTime.Now; // Присваиваем текущую дату, если DatePosted == null

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

            request.Adapt(post);
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
