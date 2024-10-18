using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.FileContracts;
using Domain.Interfaces;
using Domain.Models1;
using Domain.Results;
using Domain.Wrapper;
using Mapster;
using FileModel = Domain.Models1.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private readonly IRepositoryWrapper _repository;

        public FileService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> AddFileAsync(UploadFileRequest fileRequest)
        {
            var file = fileRequest.Adapt<FileModel>();
            await _repository.File.CreateAsync(file);
            await _repository.SaveAsync();
            return ServiceResult.SuccessResult("Файл успешно загружен", file);
        }

        public async Task<IEnumerable<GetFileResponse>> GetFilesByUserAsync(int userId)
        {
            var files = await _repository.File.GetFilesByUserAsync(userId);
            return files.Adapt<IEnumerable<GetFileResponse>>();
        }

        public async Task<ServiceResult> UploadFileAsync(UploadFileRequest request)
        {
            var file = request.Adapt<FileModel>();
            await _repository.File.CreateAsync(file);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Файл успешно загружен", file);
        }

        public async Task<ServiceResult> UpdateFileAsync(UpdateFileRequest request)
        {
            var file = await _repository.File.GetByIdAsync(request.IdFile);
            if (file == null)
            {
                return ServiceResult.ErrorResult("Файл не найден");
            }

            request.Adapt(file);
            await _repository.File.UpdateAsync(file);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Файл успешно обновлен", file);
        }

        public async Task<ServiceResult> DeleteFileAsync(int id)
        {
            var file = await _repository.File.GetByIdAsync(id);
            if (file == null)
            {
                return ServiceResult.ErrorResult("Файл не найден");
            }

            await _repository.File.DeleteAsync(file);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Файл успешно удален");
        }

        public async Task<ServiceResult> SetFileAccessAsync(int fileId, int userId, string accessType)
        {
            // Логика для назначения прав доступа
            var fileAccess = new Domain.Models1.FileAccess
            {
                IdFile = fileId,
                IdUser = userId,
                AccessType = accessType
            };

            await _repository.FileAccess.CreateAsync(fileAccess);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Доступ успешно установлен", fileAccess);
        }
    }
}
