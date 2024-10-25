using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Domain.Results;
using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces
{
    public interface IMediaService
    {
        Task<ServiceResult> UploadPostMediaAsync(int postId, IFormFile file);
        Task<ServiceResult> UploadCourseMediaAsync(int courseId, IFormFile file);
        Task<ServiceResult> UpdateMediaAsync(int mediaId, IFormFile newFile);
        Task<ServiceResult> DeleteMediaAsync(int mediaId);
    }
}
