﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.FileContracts;
using Domain.Interfaces;
using Domain.Models;
using Domain.Results;
using Domain.Wrapper;
using FileModel = Domain.Models.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private readonly IRepositoryWrapper _repository;

        public FileService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetFileResponse>> GetFilesByUserAsync(int userId)
        {
            var files = await _repository.File.GetFilesByUserAsync(userId);
            return files.Select(f => new GetFileResponse
            {
                IdFile = f.IdFile,
                FileName = f.NameFile,
                FileType = f.FileType,
                FilePath = f.FilePath
            });
        }

        // Добавление файла
        public async Task<ServiceResult> AddFileAsync(CreateFileRequest fileRequest)
        {
            var file = new FileModel
            {
                NameFile = fileRequest.FileName,
                FileType = fileRequest.FileType,
                FilePath = fileRequest.FilePath,
                IdUser = fileRequest.IdUser
            };
            await _repository.File.CreateAsync(file);
            await _repository.SaveAsync();
            return ServiceResult.SuccessResult("Файл успешно добавлен", file);
        }

        // Обновление файла
        public async Task<ServiceResult> UpdateFileAsync(UpdateFileRequest request)
        {
            var file = await _repository.File.GetByIdAsync(request.IdFile);
            if (file == null)
            {
                return ServiceResult.ErrorResult("Файл не найден");
            }

            file.NameFile = request.FileName;
            file.FileType = request.FileType;
            await _repository.File.UpdateAsync(file);
            await _repository.SaveAsync();

            return ServiceResult.SuccessResult("Файл успешно обновлен", file);
        }

        // Удаление файла
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
    }
}
