using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.DTO;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using FileModel = DataAccess.Models.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private readonly IRepositoryWrapper _repository;

        public FileService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FileDTO>> GetFilesByUserAsync(int userId)
        {
            var files = await _repository.File.GetFilesByUserAsync(userId);
            return files.Select(f => new FileDTO
            {
                IdFile = f.IdFile,
                NameFile = f.NameFile,
                FileType = f.FileType,
                FilePath = f.FilePath
            });
        }

        public async Task AddFileAsync(FileDTO fileDto)
        {
            var file = new FileModel
            {
                NameFile = fileDto.NameFile,
                FileType = fileDto.FileType,
                FilePath = fileDto.FilePath,
                IdUser = fileDto.IdUser
            };
            await _repository.File.AddFileAsync(file);
        }
    }
}
