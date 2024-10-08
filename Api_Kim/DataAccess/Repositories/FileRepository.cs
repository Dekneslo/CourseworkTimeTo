﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FileModel = Domain.Models.File;

namespace DataAccess.Repositories
{
    public class FileRepository : RepositoryBase<FileModel>, IFileRepository
    {
        public FileRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<FileModel>> GetFilesByUserAsync(int userId)
        {
            return await FindByConditionAsync(file => file.IdUser == userId);
        }

        public async Task AddFileAsync(FileModel file)
        {
            await CreateAsync(file);
            await SaveAsync();
        }

        public async Task<FileModel> GetByIdAsync(int id)
        {
            var files = await FindByConditionAsync(file => file.IdFile == id); 
            return files.FirstOrDefault();
        }

        public async Task UpdateFileAsync(FileModel file)
        {
            UpdateAsync(file);
            await SaveAsync();
        }

        public async Task DeleteFileAsync(FileModel file)
        {
            DeleteAsync(file);
            await SaveAsync();
        }
    }
}
