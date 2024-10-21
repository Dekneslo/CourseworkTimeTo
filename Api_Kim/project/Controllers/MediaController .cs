using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpPost("post/{postId}/upload")]
    public async Task<IActionResult> UploadPostMedia(int postId, [FromForm] IFormFile file)
    {
        var result = await _mediaService.UploadPostMediaAsync(postId, file);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPost("course/{courseId}/upload")]
    public async Task<IActionResult> UploadCourseMedia(int courseId, [FromForm] IFormFile file)
    {
        var result = await _mediaService.UploadCourseMediaAsync(courseId, file);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPut("{mediaId}/update")]
    public async Task<IActionResult> UpdateMedia(int mediaId, [FromForm] IFormFile newFile)
    {
        var result = await _mediaService.UpdateMediaAsync(mediaId, newFile);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpDelete("{mediaId}")]
    public async Task<IActionResult> DeleteMedia(int mediaId)
    {
        var result = await _mediaService.DeleteMediaAsync(mediaId);
        if (!result.Success) return BadRequest(result.Errors);
        return NoContent();
    }

}
