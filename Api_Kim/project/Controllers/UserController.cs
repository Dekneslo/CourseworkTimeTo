using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Results;
using Domain.Models;
using Domain.Contracts.UserContracts;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     GET /api/User
        /// 
        /// </remarks>
        /// <returns>Список всех пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Получение пользователя по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/User/1
        ///
        /// </remarks>
        /// <param name="id">ID пользователя</param>
        /// <returns>Информация о пользователе</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /api/User
        ///     {
        ///        "FirstName" : "Иван",
        ///        "LastName" : "Иванов",
        ///        "Email" : "ivanov@example.com",
        ///        "Password" : "!Pa$$word123"
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Данные для регистрации пользователя</param>
        /// <returns>Ответ с результатом операции</returns>
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.RegisterUserAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        /// POST /api/User
        /// {
        ///     "FirstName": "Иван",
        ///     "LastName": "Иванов",
        ///     "Email": "ivanov@example.com",
        ///     "Password": "StrongPassword123!"
        /// }
        /// </remarks>
        /// <param name="request">Запрос на создание пользователя</param>
        /// <returns>Созданный пользователь</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _userService.CreateUserAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Обновление информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /api/User/1
        ///     {
        ///        "FirstName" : "Иван",
        ///        "LastName" : "Иванов",
        ///        "Email" : "ivanov_new@example.com"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">ID пользователя</param>
        /// <param name="request">Данные для обновления пользователя</param>
        /// <returns>Ответ с результатом операции</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            var result = await _userService.UpdateUserAsync(id, request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     DELETE /api/User/1
        /// 
        /// </remarks>
        /// <param name="id">ID пользователя</param>
        /// <returns>Ответ с результатом операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result.Success) return BadRequest(result.Errors);
            return NoContent();
        }

        /// <summary>
        /// Получение пользователей по роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/User/byRole/Admin
        ///
        /// </remarks>
        /// <param name="role">Роль пользователя</param>
        /// <returns>Список пользователей с указанной ролью</returns>
        [HttpGet("byRole/{role}")]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            var users = await _userService.GetUsersByRoleAsync(role);
            return Ok(users);
        }
    }
}
