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

namespace BusinessLogic.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<ServiceResult> UploadPostMediaAsync(int postId, IFormFile file)
        {
            var media = await SaveFileAsync(file);
            await _mediaRepository.UploadPostMediaAsync(postId, media);
            return ServiceResult.SuccessResult("Медиафайл загружен", media);
        }

        public async Task<ServiceResult> UploadCourseMediaAsync(int courseId, IFormFile file)
        {
            var media = await SaveFileAsync(file);
            await _mediaRepository.UploadCourseMediaAsync(courseId, media);
            return ServiceResult.SuccessResult("Медиафайл загружен", media);
        }

        public async Task<ServiceResult> UpdateMediaAsync(int mediaId, IFormFile newFile)
        {
            var media = await SaveFileAsync(newFile);
            await _mediaRepository.UpdateMediaAsync(mediaId, media);
            return ServiceResult.SuccessResult("Медиафайл обновлен", media);
        }

        public async Task<ServiceResult> DeleteMediaAsync(int mediaId)
        {
            await _mediaRepository.DeleteMediaAsync(mediaId);
            return ServiceResult.SuccessResult("Медиафайл удален");
        }

        private async Task<Domain.Models.File> SaveFileAsync(IFormFile file)
        {
            var filePath = Path.Combine("uploads", file.FileName); // Путь для сохранения
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new Domain.Models.File
            {
                FilePath = filePath,
                FileSize = file.Length,
                FileType = file.ContentType,
                NameFile = file.FileName
            };
        }
    }
}
