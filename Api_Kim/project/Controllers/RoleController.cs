using Domain.Contracts.FileContracts;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Contracts.RoleContracts;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var result = await _roleService.CreateRoleAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequest request)
        {
            var result = await _roleService.UpdateRoleAsync(id, request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (!result.Success) return BadRequest(result.Errors);
            return NoContent();
        }
    }

}
