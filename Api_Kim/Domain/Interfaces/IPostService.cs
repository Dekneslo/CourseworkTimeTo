using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.PostContracts;
using Domain.Results;

namespace Domain.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<GetPostResponse>> GetAllPostsAsync();
        Task<IEnumerable<GetDailyUpdateResponse>> GetAllDailyUpdatesAsync(); // Новый метод для получения обновлений
        Task<ServiceResult> CreatePostAsync(CreatePostRequest postRequest);
        Task<ServiceResult> CreateDailyUpdateAsync(CreateDailyUpdateRequest updateRequest); // Новый метод для создания обновлений
        Task<ServiceResult> UpdatePostAsync(UpdatePostRequest request);
        Task<ServiceResult> DeletePostAsync(int id);
        Task<ServiceResult> LikePostAsync(int postId, int userId);
        Task<ServiceResult> AddMediaToPostAsync(AddMediaToPostRequest request);
    }
}
