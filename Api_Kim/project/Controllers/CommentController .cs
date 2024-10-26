using Domain.Contracts.CourseContracts;
using Domain.Contracts.CommentContracts;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Results;


[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    /// <summary>
    /// Добавление комментария к посту
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Comment/post/1
    ///
    /// </remarks>
    /// <param name="postId">ID поста</param>
    /// <param name="request">Запрос с данными комментария</param>
    /// <returns>Результат операции</returns>
    [HttpPost("post/{postId}")]
    public async Task<IActionResult> AddCommentToPost(int postId, [FromBody] CommentRequest request)
    {
        var result = await _commentService.AddCommentToPostAsync(postId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Добавление комментария к курсу
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Comment/course/1
    ///
    /// </remarks>
    /// <param name="courseId">ID курса</param>
    /// <param name="request">Запрос с данными комментария</param>
    /// <returns>Результат операции</returns>
    [HttpPost("course/{courseId}")]
    public async Task<IActionResult> AddCommentToCourse(int courseId, [FromBody] CommentRequest request)
    {
        var result = await _commentService.AddCommentToCourseAsync(courseId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Получение комментариев к посту
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /api/Comment/post/1
    ///
    /// </remarks>
    /// <param name="postId">ID поста</param>
    /// <returns>Комментарии к посту</returns>
    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetCommentsForPost(int postId, [FromBody] GetCommentResponse request)
    {
        var comments = await _commentService.GetCommentsForPostAsync(postId, request);
        return Ok(comments);
    }

    /// <summary>
    /// Получение комментариев к курсу
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /api/Comment/course/1
    ///
    /// </remarks>
    /// <param name="courseId">ID курса</param>
    /// <returns>Комментарии к курсу</returns>
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetCommentsForCourse(int courseId, [FromBody] GetCommentResponse request)
    {
        var comments = await _commentService.GetCommentsForCourseAsync(courseId, request);
        return Ok(comments);
    }

    /// <summary>
    /// Обновление комментария
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /api/Comment/1
    ///
    /// </remarks>
    /// <param name="commentId">ID комментария</param>
    /// <param name="request">Запрос с обновленными данными комментария</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{commentId}")]
    public async Task<IActionResult> UpdateComment(int commentId, [FromBody] UpdateCommentRequest request)
    {
        var result = await _commentService.UpdateCommentAsync(commentId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Удаление комментария
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /api/Comment/1
    ///
    /// </remarks>
    /// <param name="commentId">ID комментария</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{commentId}")]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var result = await _commentService.DeleteCommentAsync(commentId);
        if (!result.Success) return BadRequest(result.Errors);
        return NoContent();
    }

}
