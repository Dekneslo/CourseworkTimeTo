using Microsoft.AspNetCore.Mvc;
using Domain.Contracts.UserContracts;
using Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public UserProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    /// <summary>
    /// Получение профиля пользователя по ID
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     GET /api/UserProfile/1
    /// 
    /// </remarks>
    /// <param name="userId">ID пользователя</param>
    /// <returns>Профиль пользователя</returns>
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetProfileByUserId(int userId)
    {
        var profile = await _profileService.GetProfileByUserIdAsync(userId);
        if (profile == null) return NotFound();
        return Ok(profile);
    }

    /// <summary>
    /// Создание или обновление профиля пользователя
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST /api/UserProfile/1
    ///     {
    ///        "City": "Алматы",
    ///        "Country": "Казахстан",
    ///        "PhoneNumber": "+77012345678"
    ///     }
    /// 
    /// </remarks>
    /// <param name="userId">ID пользователя</param>
    /// <param name="request">Запрос на обновление профиля</param>
    /// <returns>Результат операции</returns>
    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateOrUpdateProfile(int userId, [FromBody] UpdateProfileRequest request)
    {
        var result = await _profileService.CreateOrUpdateProfileAsync(userId, request);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }

    /// <summary>
    /// Изменение языка интерфейса пользователя
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     PUT /api/UserProfile/1/language
    ///     {
    ///        "LanguageCode": "EN"
    ///     }
    /// 
    /// </remarks>
    /// <param name="userId">ID пользователя</param>
    /// <param name="request">Запрос на изменение языка</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{userId}/language")]
    public async Task<IActionResult> ChangeUserLanguage(int userId, [FromBody] ChangeUserLanguageRequest request)
    {
        var result = await _profileService.ChangeUserLanguageAsync(userId, request.LanguageCode);
        if (!result.Success) return BadRequest(result.Errors);
        return Ok(result.Data);
    }
}
