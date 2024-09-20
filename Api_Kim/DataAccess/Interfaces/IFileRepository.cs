using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using FileModel = DataAccess.Models.File;

namespace DataAccess.Interfaces
{
    public interface IFileRepository : IRepositoryBase<FileModel>
    {
        Task<IEnumerable<FileModel>> GetFilesByUserAsync(int userId); // Получить файлы по пользователю
        Task AddFileAsync(FileModel file); // Добавить новый файл
    }
}
