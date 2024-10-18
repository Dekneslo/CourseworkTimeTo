using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models1;
using FileModel = Domain.Models1.File;

namespace Domain.Interfaces
{
    public interface IFileRepository : IRepositoryBase<FileModel>
    {
        Task<List<FileModel>> GetFilesByUserAsync(int userId); // Получить файлы по пользователю
        Task AddFileAsync(FileModel file); // Добавить новый файл
        Task<FileModel> GetByIdAsync(int id);
    }
}
