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
        private ICourseMediaRepository _courseMedia;
        private IPostRepository _post;
        private IMessageRepository _message;
        private IFileRepository _file;
        private IFileAccessRepository _fileAccess;
        private IUserLanguageRepository _userLanguage;
        private IRoleRepository _role;
        private IUserCourseRepository _userCourse;
        private IChatRepository _chat;
        private IDailyUpdateRepository _dailyUpdate;

        public IDailyUpdateRepository DailyUpdate // Implement DailyUpdate property
        {
            get
            {
                if (_dailyUpdate == null)
                {
                    _dailyUpdate = new DailyUpdateRepository(_repoContext);
                }
                return _dailyUpdate;
            }
        }

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

        public ICourseMediaRepository CourseMedia // Реализация CourseMedia
        {
            get
            {
                if (_courseMedia == null)
                {
                    _courseMedia = new CourseMediaRepository(_repoContext);
                }
                return _courseMedia;
            }
        }

        public IUserCourseRepository UserCourse
        {
            get
            {
                if (_userCourse == null)
                {
                    _userCourse = new UserCourseRepository(_repoContext);
                }
                return _userCourse;
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

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }

        public IUserLanguageRepository UserLanguage
        {
            get
            {
                if (_userLanguage == null)
                {
                    _userLanguage = new UserLanguageRepository(_repoContext);
                }
                return _userLanguage;
            }
        }

        public IChatRepository Chat
        {
            get
            {
                if (_chat == null)
                {
                    _chat = new ChatRepository(_repoContext);
                }
                return _chat;
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
