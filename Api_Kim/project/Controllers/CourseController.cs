using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Contracts.CourseContracts;
using Domain.Contracts.LikeContracts;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Получение всех курсов
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/Course
        ///
        /// </remarks>
        /// <returns>Список всех курсов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        /// <summary>
        /// Получение информации о курсе по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     GET /api/Course/1
        /// 
        /// </remarks>
        /// <param name="id">ID курса</param>
        /// <returns>Информация о курсе</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        /// <summary>
        /// Создание нового курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /api/Course
        ///     {
        ///        "NameCourse" : "Программирование на C#",
        ///        "Description" : "Курс по основам программирования на C#",
        ///        "IdCategory" : 1
        ///     }
        /// 
        /// </remarks>
        /// <param name="courseDto">Модель курса</param>
        /// <returns>Созданный курс</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest courseRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _courseService.CreateCourseAsync(courseRequest);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Обновление курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /api/Course/1
        ///     {
        ///        "NameCourse" : "Программирование на C# - Обновленный",
        ///        "Description" : "Обновленная информация по курсу"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">ID курса</param>
        /// <param name="courseDto">Модель для обновления курса</param>
        /// <returns>Обновленный курс</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CreateCourseRequest courseRequest)
        {
            var result = await _courseService.UpdateCourseAsync(id, courseRequest);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Удаление курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     DELETE /api/Course/1
        /// 
        /// </remarks>
        /// <param name="id">ID курса</param>
        /// <returns>Результат операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }

        [HttpPost("{courseId}/like")]
        public async Task<IActionResult> LikeCourse(int courseId, [FromBody] LikeRequest request)
        {
            if (request.EntityId != courseId)
            {
                return BadRequest("Некорректный ID курса.");
            }

            var result = await _courseService.LikeCourseAsync(courseId, request.UserId);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        [HttpPost("{courseId}/comment")]
        public async Task<IActionResult> CommentOnCourse(int courseId, [FromBody] CommentRequest comment)
        {
            var result = await _courseService.AddCommentAsync(courseId, comment);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }
    }
}
