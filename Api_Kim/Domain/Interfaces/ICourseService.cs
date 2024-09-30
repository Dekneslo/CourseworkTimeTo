using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Results;
using Domain.DTO;

namespace Domain.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDTO>> GetAllCoursesAsync();
        Task<List<CourseDTO>> GetCourseByIdAsync(int id);
        Task<ServiceResult> CreateCourseAsync(CourseDTO courseDto);
        Task<ServiceResult> UpdateCourseAsync(int id, CourseDTO courseDto);
        Task<ServiceResult> DeleteCourseAsync(int id);
        Task<List<CourseDTO>> GetCoursesByCategoryAsync(int categoryId);
    }
}
