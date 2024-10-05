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
    }
}
