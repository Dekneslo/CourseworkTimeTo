using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Results;
using DataAccess.DTO;

namespace BusinessLogic.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(int id);
        Task<ServiceResult> CreateCourseAsync(CourseDTO courseDto);
        Task<ServiceResult> UpdateCourseAsync(int id, CourseDTO courseDto);
        Task<ServiceResult> DeleteCourseAsync(int id);
        Task<IEnumerable<CourseDTO>> GetCoursesByCategoryAsync(int categoryId);
    }
}
