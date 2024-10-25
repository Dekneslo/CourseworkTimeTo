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
    public async Task<IActionResult> GetCommentsForPost(int postId, [FromBody] GetCommentResponse request)
    {
        var comments = await _commentService.GetCommentsForPostAsync(postId, request);
        return Ok(comments);
    }

    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetCommentsForCourse(int courseId, [FromBody] GetCommentResponse request)
    {
        var comments = await _commentService.GetCommentsForCourseAsync(courseId, request);
        return Ok(comments);
    }

    [HttpPut("{commentId}")]
    public async Task<IActionResult> UpdateComment(int commentId, [FromBody] UpdateCommentRequest request)
    {
        var result = await _commentService.UpdateCommentAsync(commentId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpDelete("{commentId}")]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var result = await _commentService.DeleteCommentAsync(commentId);
        if (!result.Success) return BadRequest(result.Errors);
        return NoContent();
    }

}
