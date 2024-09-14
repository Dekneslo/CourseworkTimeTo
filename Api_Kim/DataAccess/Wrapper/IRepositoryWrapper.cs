using DataAccess.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        //IUserRepository User { get; }
        //void Save();
        IUserRepository UserRepository { get; }
        ICourseRepository CourseRepository { get; }
        Task SaveAsync(); // Метод для сохранения всех изменений
    }
}
