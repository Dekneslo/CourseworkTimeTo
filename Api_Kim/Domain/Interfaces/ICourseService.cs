using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.CommentContracts;
using Domain.Contracts.CourseContracts;
using Domain.Contracts.MessageContracts;
using Domain.Results;

namespace Domain.Interfaces
{
    public interface ICourseService
    {
        Task<List<GetCourseResponse>> GetAllCoursesAsync();
        Task<GetCourseResponse> GetCourseByIdAsync(int id);
        Task<ServiceResult> CreateCourseAsync(CreateCourseRequest courseRequest);
        Task<ServiceResult> UpdateCourseAsync(int id, CreateCourseRequest courseRequest);
        Task<ServiceResult> DeleteCourseAsync(int id);
        Task<List<GetCourseResponse>> GetCoursesByCategoryAsync(int categoryId);
        Task<ServiceResult> LikeCourseAsync(int courseId, int userId);
        Task<ServiceResult> AddCommentAsync(int courseId, AddCommentRequest commentRequest);  
        Task<ServiceResult> AddMediaToCourseAsync(AddMediaToCourseRequest request);  
        Task<ServiceResult> EnrollUserInCourseAsync(int courseId, int userId);
        Task<ServiceResult> UnenrollUserFromCourseAsync(int courseId, int userId);
    }
}
