using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public UserProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetProfileByUserId(int userId)
    {
        var profile = await _profileService.GetProfileByUserIdAsync(userId);
        if (profile == null) return NotFound();
        return Ok(profile);
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateOrUpdateProfile(int userId, [FromBody] UpdateProfileRequest request)
    {
        var result = await _profileService.CreateOrUpdateProfileAsync(userId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    [HttpPut("{userId}/language")]
    public async Task<IActionResult> ChangeUserLanguage(int userId, [FromBody] ChangeLanguageRequest request)
    {
        var result = await _profileService.ChangeUserLanguageAsync(userId, request.LanguageCode);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

}
