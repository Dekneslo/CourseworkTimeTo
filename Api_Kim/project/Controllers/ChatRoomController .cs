using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChatRoomController : ControllerBase
{
    private readonly IChatRoomService _chatRoomService;

    public ChatRoomController(IChatRoomService chatRoomService)
    {
        _chatRoomService = chatRoomService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateChatRoom([FromBody] CreateChatRoomRequest request)
    {
        var result = await _chatRoomService.CreateChatRoomAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPost("{chatRoomId}/add-user")]
    public async Task<IActionResult> AddUserToChatRoom(int chatRoomId, [FromBody] ChatRoomUserRequest request)
    {
        var result = await _chatRoomService.AddUserToChatRoomAsync(chatRoomId, request.UserId);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPost("{chatRoomId}/remove-user")]
    public async Task<IActionResult> RemoveUserFromChatRoom(int chatRoomId, [FromBody] ChatRoomUserRequest request)
    {
        var result = await _chatRoomService.RemoveUserFromChatRoomAsync(chatRoomId, request.UserId);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }
}
