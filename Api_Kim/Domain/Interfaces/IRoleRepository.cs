﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<Role> GetByIdAsync(int id);
        Task<List<Role>> GetAllAsync();
    }
}
