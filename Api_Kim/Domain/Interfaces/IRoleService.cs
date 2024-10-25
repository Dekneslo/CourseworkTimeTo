using Domain.Contracts.RoleContracts;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetAllRolesAsync();
        Task<ServiceResult> CreateRoleAsync(CreateRoleRequest request);
        Task<ServiceResult> UpdateRoleAsync(int id, UpdateRoleRequest request);
        Task<ServiceResult> DeleteRoleAsync(int id);
    }
}
