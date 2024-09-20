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
        //Task<IEnumerable<T>> FindAll(); // Получить все записи
        //Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression); // Найти записи по условию
        //void Create(T entity); // Создать запись
        //void Update(T entity); // Обновить запись
        //void Delete(T entity); // Удалить запись
        //Task SaveAsync(); // Сохранить изменения
    }
}
