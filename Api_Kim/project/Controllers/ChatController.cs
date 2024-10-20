using Domain.Contracts.ChatContracts;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChatRoom([FromBody] CreateChatRoomRequest request)
        {
            var result = await _chatService.CreateChatRoomAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        [HttpPost("{chatRoomId}/addUser")]
        public async Task<IActionResult> AddUserToChat(int chatRoomId, [FromBody] AddUserToChatRequest request)
        {
            request.ChatRoomId = chatRoomId;
            var result = await _chatService.AddUserToChatAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        [HttpPost("{chatRoomId}/removeUser")]
        public async Task<IActionResult> RemoveUserFromChat(int chatRoomId, [FromBody] RemoveUserFromChatRequest request)
        {
            request.ChatRoomId = chatRoomId;
            var result = await _chatService.RemoveUserFromChatAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }
    }

}
