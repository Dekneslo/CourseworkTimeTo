using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models1;
using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CharityDB1Context RepositoryContext { get; set; }

        public RepositoryBase(CharityDB1Context repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task<List<T>> FindAllAsync() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

        public async Task UpdateAsync(T entity) => RepositoryContext.Set<T>().Update(entity);

        public async Task DeleteAsync(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public async Task SaveAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
