using Domain.Contracts.CommentContracts;
using Domain.Contracts.CourseContracts;
using Domain.Interfaces;
using Domain.Models;
using Domain.Results;
using Domain.Wrapper;
using Mapster;

namespace BusinessLogic.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CourseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GetCourseResponse>> GetAllCoursesAsync()
        {
            var courses = await _repositoryWrapper.Course.GetAllAsync();
            return courses.Adapt<List<GetCourseResponse>>();
        }

        public async Task<GetCourseResponse> GetCourseByIdAsync(int id)
        {
            var course = await _repositoryWrapper.Course.GetByIdAsync(id);
            if (course == null)
            {
                return null;
            }

            return course.Adapt<GetCourseResponse>();
        }

        public async Task<ServiceResult> CreateCourseAsync(CreateCourseRequest courseRequest)
        {
            var course = courseRequest.Adapt<Course>();  // Использование Mapster для адаптации
            course.DateCreated = DateTime.Now;  // Присвоение текущей даты

            await _repositoryWrapper.Course.CreateAsync(course);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Курс успешно создан", course);
        }

        public async Task<ServiceResult> UpdateCourseAsync(int id, CreateCourseRequest courseRequest)
        {
            var course = await _repositoryWrapper.Course.GetByIdAsync(id);
            if (course == null)
            {
                return ServiceResult.ErrorResult("Курс не найден");
            }

            courseRequest.Adapt(course);

            await _repositoryWrapper.Course.UpdateAsync(course);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Курс успешно обновлен", course);
        }

        public async Task<ServiceResult> DeleteCourseAsync(int id)
        {
            var course = await _repositoryWrapper.Course.GetByIdAsync(id);
            if (course == null)
            {
                return ServiceResult.ErrorResult("Курс не найден");
            }

            await _repositoryWrapper.Course.DeleteAsync(course);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Курс успешно удален");
        }

        // Получить курсы по категории
        public async Task<List<GetCourseResponse>> GetCoursesByCategoryAsync(int categoryId)
        {
            var courses = await _repositoryWrapper.Course.GetCoursesByCategoryAsync(categoryId);
            return courses.Adapt<List<GetCourseResponse>>();  // Адаптируем List<Course> в List<GetCourseResponse>
        }

        // Добавляем метод для лайка курса
        public async Task<ServiceResult> LikeCourseAsync(int courseId, int userId)
        {
            await _repositoryWrapper.Course.LikeCourseAsync(courseId, userId);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Лайк успешно добавлен");
        }

        // Добавляем метод для добавления комментария к курсу
        public async Task<ServiceResult> AddCommentAsync(int courseId, AddCommentRequest commentRequest)
        {
            var courseComment = new Comment
            {
                IdUser = commentRequest.UserId,
                IdCourse = courseId,
                CommentDescription = commentRequest.CommentText,
                DateCommented = DateTime.Now
            };

            await _repositoryWrapper.Course.AddCommentAsync(courseId, courseComment);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Комментарий успешно добавлен", courseComment);
        }

        public async Task<ServiceResult> AddMediaToCourseAsync(AddMediaToCourseRequest request)
        {
            // Реализация логики добавления медиафайла
            var courseMedia = new CourseMedium
            {
                IdCourse = request.CourseId,
                IdFile = request.FileId
            };

            await _repositoryWrapper.CourseMedia.CreateAsync(courseMedia);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Медиафайл успешно добавлен", courseMedia);
        }

        public async Task<ServiceResult> EnrollUserInCourseAsync(int courseId, int userId)
        {
            var userCourse = new UsersCourse
            {
                IdCourse = courseId,
                IdUser = userId
            };

            await _repositoryWrapper.UserCourse.CreateAsync(userCourse);
            await _repositoryWrapper.SaveAsync();
            return ServiceResult.SuccessResult("Пользователь успешно записан на курс", userCourse);
        }

        public async Task<ServiceResult> UnenrollUserFromCourseAsync(int courseId, int userId)
        {
            var userCourse = await _repositoryWrapper.UserCourse.GetByCourseAndUserAsync(courseId, userId);
            if (userCourse == null)
            {
                return ServiceResult.ErrorResult("Пользователь не записан на этот курс.");
            }

            await _repositoryWrapper.UserCourse.DeleteAsync(userCourse);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Пользователь успешно отписан от курса.");
        }
    }
}
