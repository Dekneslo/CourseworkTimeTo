using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> FindAllAsync();

        // Найти записи по условию
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        // Создать запись
        Task CreateAsync(T entity);

        // Обновить запись
        Task UpdateAsync(T entity);

        // Удалить запись
        Task DeleteAsync(T entity);

        // Сохранить изменения
        Task SaveAsync();
    }
}
