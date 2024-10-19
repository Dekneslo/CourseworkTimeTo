using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ICourseRepository Course { get; }
        IPostRepository Post { get; }
        IMessageRepository Message { get; }
        IFileRepository File { get; }
        IFileAccessRepository FileAccess { get; }
        Task SaveAsync();
    }
}