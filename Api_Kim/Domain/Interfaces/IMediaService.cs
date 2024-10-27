using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Domain.Results;
using Microsoft.AspNetCore.Http;
using Domain.Contracts.MediaContracts;

namespace Domain.Interfaces
{
    public interface IMediaService
    {
        Task<ServiceResult> UploadPostMediaAsync(int postId, UploadMediaRequest request);
        Task<ServiceResult> UploadCourseMediaAsync(int courseId, UploadMediaRequest request);
        Task<ServiceResult> UpdateMediaAsync(int mediaId, UploadMediaRequest request);
        Task<ServiceResult> DeleteMediaAsync(int mediaId);
    }
}
