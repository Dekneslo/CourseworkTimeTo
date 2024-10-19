using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFileAccessRepository : IRepositoryBase<Domain.Models.FileAccess>
    {
        // Вы можете добавить дополнительные методы, если необходимо
    }
}

