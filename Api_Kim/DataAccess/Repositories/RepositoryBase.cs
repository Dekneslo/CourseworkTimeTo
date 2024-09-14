using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Linq.Expressions;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CharityDBContext RepositoryContext { get; set; }
        public RepositoryBase(CharityDBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await RepositoryContext.Set<T>().ToListAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await RepositoryContext.Set<T>().FindAsync(id);
        //}

        //public async Task CreateAsync(T entity)
        //{
        //    await RepositoryContext.Set<T>().AddAsync(entity);
        //    await RepositoryContext.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    RepositoryContext.Set<T>().Update(entity);
        //    await RepositoryContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(T entity)
        //{
        //    RepositoryContext.Set<T>().Remove(entity);
        //    await RepositoryContext.SaveChangesAsync();
        //}
    }
}
