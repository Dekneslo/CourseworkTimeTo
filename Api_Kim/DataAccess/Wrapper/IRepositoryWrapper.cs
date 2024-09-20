using DataAccess.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ICourseRepository Course { get; }
        IPostRepository Post { get; }
        IMessageRepository Message { get; }
        IFileRepository File { get; }
        Task SaveAsync();
    }
}
