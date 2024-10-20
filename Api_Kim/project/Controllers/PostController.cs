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

        [HttpPost("{postId}/like")]
        public async Task<IActionResult> LikePost(int postId, [FromBody] LikeRequest request)
        {
            var result = await _postService.LikePostAsync(postId, request.UserId);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

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
