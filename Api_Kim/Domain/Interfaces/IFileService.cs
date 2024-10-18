using Domain.Contracts.FileContracts;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<GetFileResponse>> GetFilesByUserAsync(int userId);
        Task<ServiceResult> AddFileAsync(UploadFileRequest request);
        Task<ServiceResult> UpdateFileAsync(UpdateFileRequest request);
        Task<ServiceResult> UploadFileAsync(UploadFileRequest request);
        Task<ServiceResult> DeleteFileAsync(int id);
        // Добавляем метод для управления доступом к файлам
        Task<ServiceResult> SetFileAccessAsync(int fileId, int userId, string accessType);
    }
}
