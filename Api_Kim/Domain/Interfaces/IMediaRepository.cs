using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMediaRepository
    {
        Task UploadPostMediaAsync(int postId, Domain.Models.File media);
        Task UploadCourseMediaAsync(int courseId, Domain.Models.File media);
        Task UpdateMediaAsync(int mediaId, Domain.Models.File newMedia);
        Task DeleteMediaAsync(int mediaId);
    }
}
