using Domain.Contracts.CommentContracts;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICommentService
    {
        Task<ServiceResult> AddCommentToPostAsync(int postId, CommentRequest request);
        Task<ServiceResult> AddCommentToCourseAsync(int courseId, CommentRequest request);
        Task<List<GetCommentResponse>> GetCommentsForPostAsync(int postId, GetCommentResponse request);
        Task<List<GetCommentResponse>> GetCommentsForCourseAsync(int courseId, GetCommentResponse request);
        Task<ServiceResult> UpdateCommentAsync(int commentId, UpdateCommentRequest request);
        Task<ServiceResult> DeleteCommentAsync(int commentId);
    }
}
