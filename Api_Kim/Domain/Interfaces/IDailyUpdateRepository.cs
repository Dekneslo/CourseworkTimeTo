using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDailyUpdateRepository : IRepositoryBase<DailyUpdate>
    {
        Task<IEnumerable<DailyUpdate>> GetAllDailyUpdatesAsync();
        Task<DailyUpdate> GetDailyUpdateByIdAsync(int id);
        Task CreateDailyUpdateAsync(DailyUpdate dailyUpdate);
        Task <List<DailyUpdate>> GetAllAsync();
    }
}
