using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Results;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain.Contracts.MediaContracts;

namespace BusinessLogic.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<ServiceResult> UploadPostMediaAsync(int postId, UploadMediaRequest request)
        {
            var media = await SaveFileAsync(request);
            await _mediaRepository.UploadPostMediaAsync(postId, media);
            return ServiceResult.SuccessResult("Медиафайл загружен", media);
        }

        public async Task<ServiceResult> UploadCourseMediaAsync(int courseId, UploadMediaRequest request)
        {
            var media = await SaveFileAsync(request);
            await _mediaRepository.UploadCourseMediaAsync(courseId, media);
            return ServiceResult.SuccessResult("Медиафайл загружен", media);
        }

        public async Task<ServiceResult> UpdateMediaAsync(int mediaId, UploadMediaRequest request)
        {
            var media = await SaveFileAsync(request);
            await _mediaRepository.UpdateMediaAsync(mediaId, media);
            return ServiceResult.SuccessResult("Медиафайл обновлен", media);
        }

        public async Task<ServiceResult> DeleteMediaAsync(int mediaId)
        {
            await _mediaRepository.DeleteMediaAsync(mediaId);
            return ServiceResult.SuccessResult("Медиафайл удален");
        }

        private async Task<Domain.Models.File> SaveFileAsync(UploadMediaRequest request)
        {
            var filePath = Path.Combine("uploads", request.FileName); // Путь для сохранения
            await System.IO.File.WriteAllBytesAsync(filePath, request.FileData);

            return new Domain.Models.File
            {
                FilePath = filePath,
                FileSize = request.FileData.Length,
                FileType = request.FileType,
                NameFile = request.FileName
            };
        }
    }
}
