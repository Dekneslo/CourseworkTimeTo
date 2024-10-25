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

    /// <summary>
    /// Создание группового чата
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Chat/create-chat-room
    ///
    /// </remarks>
    /// <param name="request">Запрос с данными чата</param>
    /// <returns>Созданная комната чата</returns>
    [HttpPost("create-chat-room")]
    public async Task<IActionResult> CreateChatRoom([FromBody] CreateChatRoomRequest request)
    {
        var result = await _chatService.CreateChatRoomAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Добавление пользователя в чат
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Chat/1/add-user
    ///
    /// </remarks>
    /// <param name="chatRoomId">ID чата</param>
    /// <param name="request">Запрос на добавление пользователя</param>
    /// <returns>Результат операции</returns>
    [HttpPost("{chatRoomId}/add-user")]
    public async Task<IActionResult> AddUserToChat(int chatRoomId, [FromBody] AddUserToChatRequest request)
    {
        request.ChatRoomId = chatRoomId;
        var result = await _chatService.AddUserToChatAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Удаление пользователя из чата
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Chat/1/remove-user
    ///
    /// </remarks>
    /// <param name="chatRoomId">ID чата</param>
    /// <param name="request">Запрос на удаление пользователя</param>
    /// <returns>Результат операции</returns>
    [HttpPost("{chatRoomId}/remove-user")]
    public async Task<IActionResult> RemoveUserFromChat(int chatRoomId, [FromBody] RemoveUserFromChatRequest request)
    {
        request.ChatRoomId = chatRoomId;
        var result = await _chatService.RemoveUserFromChatAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Удаление чат-комнаты
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /api/Chat/1
    ///
    /// </remarks>
    /// <param name="chatRoomId">ID чата</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{chatRoomId}")]
    public async Task<IActionResult> DeleteChatRoom(int chatRoomId)
    {
        var result = await _chatService.DeleteChatRoomAsync(chatRoomId);
        if (!result.Success) return BadRequest(result.Errors);
        return NoContent();
    }

    /// <summary>
    /// Создание приватного чата (один-на-один)
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Chat/create-private-chat
    ///
    /// </remarks>
    /// <param name="request">Запрос на создание приватного чата</param>
    /// <returns>Результат операции</returns>
    [HttpPost("create-private-chat")]
    public async Task<IActionResult> CreatePrivateChat([FromBody] CreateChatRoomRequest request)
    {
        var result = await _chatService.CreatePrivateChatAsync(request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }
}
