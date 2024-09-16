using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task<Course> GetCourseDetailsAsync(int courseId)
        {
            return await RepositoryContext.Courses
                .Include(c => c.Materials)
                .FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
        {
            return await RepositoryContext.Courses
                .Where(c => c.Category == category)
                .ToListAsync();
        }
    }

    //public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    //{
    //    public CourseRepository(CharityDBContext repositoryContext) : base(repositoryContext)
    //    {

    //    }

    //    public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
    //    {
    //        return await RepositoryContext.Set<Course>().Where(c => c.Category == category).ToListAsync();
    //    }

    //    public async Task<IEnumerable<Course>> GetPopularCoursesAsync()
    //    {
    //        return await RepositoryContext.Set<Course>().OrderByDescending(c => c.Popularity).Take(10).ToListAsync();
    //    }

    //    public async Task AttachFileToCourseAsync(int courseId, File file)
    //    {
    //        var course = await RepositoryContext.Set<Course>().FindAsync(courseId);
    //        if (course != null)
    //        {
    //            course.Files.Add(file);
    //            await RepositoryContext.SaveChangesAsync();
    //        }
    //    }
    //}

}
