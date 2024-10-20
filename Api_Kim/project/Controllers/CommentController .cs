using Domain.Contracts.CourseContracts;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("post/{postId}")]
    public async Task<IActionResult> AddCommentToPost(int postId, [FromBody] CommentRequest request)
    {
        var result = await _commentService.AddCommentToPostAsync(postId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPost("course/{courseId}")]
    public async Task<IActionResult> AddCommentToCourse(int courseId, [FromBody] CommentRequest request)
    {
        var result = await _commentService.AddCommentToCourseAsync(courseId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetCommentsForPost(int postId)
    {
        var comments = await _commentService.GetCommentsForPostAsync(postId);
        return Ok(comments);
    }

    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetCommentsForCourse(int courseId)
    {
        var comments = await _commentService.GetCommentsForCourseAsync(courseId);
        return Ok(comments);
    }
}
