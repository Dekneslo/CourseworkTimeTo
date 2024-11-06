using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class DailyUpdateRepository : RepositoryBase<DailyUpdate>, IDailyUpdateRepository
    {
        public DailyUpdateRepository(CharityDBContext context) : base(context) { }

        public async Task<List<DailyUpdate>> GetAllAsync()
        {
            return await FindAllAsync();
        }

        public async Task<IEnumerable<DailyUpdate>> GetAllDailyUpdatesAsync()
        {
            return await FindAllAsync();
        }

        public async Task<DailyUpdate> GetDailyUpdateByIdAsync(int id)
        {
            var updates = await FindByConditionAsync(update => update.IdUpdate == id);
            return updates.FirstOrDefault();
        }

        public async Task CreateDailyUpdateAsync(DailyUpdate dailyUpdate)
        {
            await CreateAsync(dailyUpdate);
        }
    }
}
