using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CharityDBContext _repoContext;
        private IUserRepository _user;
        private ICourseRepository _course;

        public RepositoryWrapper(CharityDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
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

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }

    //public class RepositoryWrapper : IRepositoryWrapper
    //{
    //    private CharityDBContext _repoContext;
    //    private IUserRepository _user;
    //    private ICourseRepository _courseRepository;
    //    public IUserRepository User
    //    {
    //        get
    //        {
    //            if (_user == null)
    //            {
    //                _user = new UserRepository(_repoContext);
    //            }
    //            return _user;
    //        }
    //    }

    //    public ICourseRepository CourseRepository
    //    {
    //        get
    //        {
    //            if (_courseRepository == null)
    //            {
    //                _courseRepository = new CourseRepository(_context);
    //            }
    //            return _courseRepository;
    //        }
    //    }

    //    public RepositoryWrapper(CharityDBContext repositoryContext)
    //    {
    //        _repoContext = repositoryContext;
    //    }
    //    //public void Save()
    //    //{
    //    //    _repoContext.SaveChanges();
    //    //}
    //    public async Task SaveAsync()
    //    {
    //        await RepositoryContext.SaveChangesAsync();
    //    }
    //}
}
