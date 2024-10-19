using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataAccess.Repositories;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CharityDBContext _repoContext;
        private IUserRepository _user;
        private ICourseRepository _course;
        private IPostRepository _post;
        private IMessageRepository _message;
        private IFileRepository _file;
        private IFileAccessRepository _fileAccess;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public ICourseRepository Course
        {
            get
            {
                if (_course == null)
                {
                    _course = new CourseRepository(_repoContext);
                }
                return _course;
            }
        }

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_repoContext);
                }
                return _post;
            }
        }

        public IMessageRepository Message
        {
            get
            {
                if (_message == null)
                {
                    _message = new MessageRepository(_repoContext);
                }
                return _message;
            }
        }

        public IFileRepository File
        {
            get
            {
                if (_file == null)
                {
                    _file = new FileRepository(_repoContext);
                }
                return _file;
            }
        }

        public IFileAccessRepository FileAccess // Реализация FileAccess
        {
            get
            {
                if (_fileAccess == null)
                {
                    _fileAccess = new FileAccessRepository(_repoContext);
                }
                return _fileAccess;
            }
        }

        public RepositoryWrapper(CharityDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
