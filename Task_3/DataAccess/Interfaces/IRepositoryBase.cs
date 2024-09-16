using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<IEnumerable<T>> GetAllAsync(); // Получение всех записей
        //Task<T> GetByIdAsync(int id); // Получение записи по ID
        //Task CreateAsync(T entity); // Создание новой записи
        //Task UpdateAsync(T entity); // Обновление существующей записи
        //Task DeleteAsy
    }
}
