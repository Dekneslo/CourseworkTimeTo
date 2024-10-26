using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    /// <summary>
    /// Загрузка медиафайла для поста
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Media/post/1/upload
    ///
    /// </remarks>
    /// <param name="postId">ID поста</param>
    /// <param name="file">Медиафайл</param>
    /// <returns>Результат операции</returns>
    [HttpPost("post/{postId}/upload")]
    public async Task<IActionResult> UploadPostMedia(int postId, [FromForm] IFormFile file)
    {
        var result = await _mediaService.UploadPostMediaAsync(postId, file);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Загрузка медиафайла для курса
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Media/course/1/upload
    ///
    /// </remarks>
    /// <param name="courseId">ID курса</param>
    /// <param name="file">Медиафайл</param>
    /// <returns>Результат операции</returns>
    [HttpPost("course/{courseId}/upload")]
    public async Task<IActionResult> UploadCourseMedia(int courseId, [FromForm] IFormFile file)
    {
        var result = await _mediaService.UploadCourseMediaAsync(courseId, file);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Обновление медиафайла
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /api/Media/1/update
    ///
    /// </remarks>
    /// <param name="mediaId">ID медиафайла</param>
    /// <param name="newFile">Новый файл для обновления</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{mediaId}/update")]
    public async Task<IActionResult> UpdateMedia(int mediaId, [FromForm] IFormFile newFile)
    {
        var result = await _mediaService.UpdateMediaAsync(mediaId, newFile);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Удаление медиафайла
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /api/Media/1
    ///
    /// </remarks>
    /// <param name="mediaId">ID медиафайла</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{mediaId}")]
    public async Task<IActionResult> DeleteMedia(int mediaId)
    {
        var result = await _mediaService.DeleteMediaAsync(mediaId);
        if (!result.Success) return BadRequest(result.Errors);
        return NoContent();
    }

}
