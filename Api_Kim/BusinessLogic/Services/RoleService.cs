using Domain.Interfaces;
using Domain.Contracts.RoleContracts;
using Domain.Models;
using Domain.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Results;
using Mapster;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<RoleResponse>> GetAllRolesAsync()
        {
            var roles = await _repositoryWrapper.Role.GetAllAsync();
            return roles.Adapt<List<RoleResponse>>();
        }

        public async Task<ServiceResult> CreateRoleAsync(CreateRoleRequest request)
        {
            var role = new Role { NameRole = request.NameRole };
            await _repositoryWrapper.Role.CreateAsync(role);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Роль успешно создана", role);
        }

        public async Task<ServiceResult> UpdateRoleAsync(int id, UpdateRoleRequest request)
        {
            var role = await _repositoryWrapper.Role.GetByIdAsync(id);
            if (role == null)
            {
                return ServiceResult.ErrorResult("Роль не найдена");
            }

            role.NameRole = request.NameRole;
            await _repositoryWrapper.Role.UpdateAsync(role);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Роль успешно обновлена", role);
        }

        public async Task<ServiceResult> DeleteRoleAsync(int id)
        {
            var role = await _repositoryWrapper.Role.GetByIdAsync(id);
            if (role == null)
            {
                return ServiceResult.ErrorResult("Роль не найдена");
            }

            await _repositoryWrapper.Role.DeleteAsync(role);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Роль успешно удалена");
        }
    }
}
