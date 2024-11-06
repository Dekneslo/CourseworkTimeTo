using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Contracts.PostContracts;
using Domain.Contracts.LikeContracts;
using Domain.Contracts.CourseContracts;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Получение всех постов
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/Post
        ///
        /// </remarks>
        /// <returns>Список постов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        /// <summary>
        /// Получение всех ежедневных обновлений
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     GET /api/Post/daily-updates
        /// 
        /// </remarks>
        /// <returns>Список ежедневных обновлений</returns>
        [HttpGet("daily-updates")]
        public async Task<IActionResult> GetAllDailyUpdates()
        {
            var updates = await _postService.GetAllDailyUpdatesAsync();
            return Ok(updates);
        }

        /// <summary>
        /// Создание нового поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /api/Post
        ///     {
        ///        "PostTitle" : "Заголовок поста",
        ///        "PostContent" : "Контент поста",
        ///        "IdUser" : 1
        ///     }
        /// 
        /// </remarks>
        /// <param name="postDto">Модель для создания поста</param>
        /// <returns>Созданный пост</returns>
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var result = await _postService.CreatePostAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Создание нового ежедневного обновления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /api/Post/daily-update
        ///     {
        ///        "Description" : "Описание обновления",
        ///        "IdUser" : 1
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Модель для создания обновления</param>
        /// <returns>Созданное обновление</returns>
        [HttpPost("daily-update")]
        public async Task<IActionResult> CreateDailyUpdate([FromBody] CreateDailyUpdateRequest request)
        {
            var result = await _postService.CreateDailyUpdateAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Обновление поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /api/Post
        ///     {
        ///         "IdPost": 1,
        ///         "PostTitle": "Обновленный заголовок",
        ///         "PostContent": "Обновленный контент поста."
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Запрос на обновление поста</param>
        /// <returns>Результат операции</returns>
        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostRequest request)
        {
            var result = await _postService.UpdatePostAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Удаление поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     DELETE /api/Post/1
        /// 
        /// </remarks>
        /// <param name="id">ID поста</param>
        /// <returns>Результат операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postService.DeletePostAsync(id);
            if (!result.Success) return BadRequest(result.Errors);
            return NoContent();
        }

        /// <summary>
        /// Лайк поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Post/1/like
        ///
        /// </remarks>
        /// <param name="postId">ID поста</param>
        /// <param name="request">Запрос с ID пользователя</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{postId}/like")]
        public async Task<IActionResult> LikePost(int postId, [FromBody] LikeRequest request)
        {
            var result = await _postService.LikePostAsync(postId, request.UserId);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Добавление медиафайла к посту
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Post/1/media
        ///
        /// </remarks>
        /// <param name="postId">ID поста</param>
        /// <param name="request">Запрос с данными для добавления медиа</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{postId}/media")]
        public async Task<IActionResult> AddMediaToPost(int postId, [FromBody] AddMediaToPostRequest request)
        {
            if (request.PostId != postId) return BadRequest("Некорректный ID поста.");
            var result = await _postService.AddMediaToPostAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }
    }
}
