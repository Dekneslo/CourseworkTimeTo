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
        Task<ServiceResult> AddFileAsync(CreateFileRequest request);
        Task<ServiceResult> UpdateFileAsync(UpdateFileRequest request);
        Task<ServiceResult> DeleteFileAsync(int id);
    }
}
