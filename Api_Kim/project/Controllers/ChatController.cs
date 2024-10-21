
using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    // Создание группового чата
    [HttpPost("create-chat-room")]
    public async Task<IActionResult> CreateChatRoom([FromBody] CreateChatRoomRequest request)
    {
        var result = await _chatService.CreateChatRoomAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    // Добавление пользователя в чат
    [HttpPost("{chatRoomId}/add-user")]
    public async Task<IActionResult> AddUserToChat(int chatRoomId, [FromBody] AddUserToChatRequest request)
    {
        request.ChatRoomId = chatRoomId;
        var result = await _chatService.AddUserToChatAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    // Удаление пользователя из чата
    [HttpPost("{chatRoomId}/remove-user")]
    public async Task<IActionResult> RemoveUserFromChat(int chatRoomId, [FromBody] RemoveUserFromChatRequest request)
    {
        request.ChatRoomId = chatRoomId;
        var result = await _chatService.RemoveUserFromChatAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    // Удаление чат-комнаты
    [HttpDelete("{chatRoomId}")]
    public async Task<IActionResult> DeleteChatRoom(int chatRoomId)
    {
        var result = await _chatService.DeleteChatRoomAsync(chatRoomId);
        if (!result.Success) return BadRequest(result.Errors);
        return NoContent();
    }

    // Создание приватного чата (один-на-один)
    [HttpPost("create-private-chat")]
    public async Task<IActionResult> CreatePrivateChat([FromBody] CreateChatRoomRequest request)
    {
        var result = await _chatService.CreatePrivateChatAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }
}
