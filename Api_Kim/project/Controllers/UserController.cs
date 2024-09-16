using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using DataAccess.Models;

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

        // Получить всех пользователей
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // Получить пользователя по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Зарегистрировать нового пользователя (клиент или сотрудник)
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (user == null) return BadRequest();
            await _userService.RegisterUser(user);
            return Ok();
        }

        // Обновить информацию о пользователе
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (user == null || id != user.Id) return BadRequest();
            await _userService.UpdateUser(user);
            return Ok();
        }

        // Удалить пользователя
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        // Изменить уровень доступа клиента (например, до VIP)
        [HttpPut("access-level/{id}")]
        public async Task<IActionResult> ChangeUserAccessLevel(int id, [FromBody] AccessLevel newAccessLevel)
        {
            await _userService.ChangeAccessLevel(id, newAccessLevel);
            return Ok();
        }
        //private IUserService _userService;
        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _userService.GetAll());
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await _userService.GetById(id));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(User user)
        //{
        //    await _userService.Create(user);
        //    return Ok();
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(User user)
        //{
        //    await _userService.Update(user);
        //    return Ok();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _userService.Delete(id);
        //    return Ok();
        //}
    }
}
