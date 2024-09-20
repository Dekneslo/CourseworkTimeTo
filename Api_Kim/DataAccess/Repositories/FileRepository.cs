using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using FileModel = DataAccess.Models.File;

namespace DataAccess.Repositories
{
    public class FileRepository : RepositoryBase<FileModel>, IFileRepository
    {
        public FileRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<FileModel>> GetFilesByUserAsync(int userId)
        {
            return await FindByCondition(file => file.IdUser == userId).ToListAsync();
        }

        public async Task AddFileAsync(FileModel file)
        {
            Create(file);
            await SaveAsync();
        }
    }
}
