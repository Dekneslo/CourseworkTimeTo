using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICourseMediaRepository : IRepositoryBase<CourseMedium>
    {
        Task AddMediaAsync(CourseMedium courseMedia);  // Метод для добавления медиафайла
    }
}
