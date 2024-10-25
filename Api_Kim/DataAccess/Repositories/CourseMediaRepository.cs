using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseMediaRepository : RepositoryBase<CourseMedium>, ICourseMediaRepository
    {
        public CourseMediaRepository(CharityDBContext repositoryContext) : base(repositoryContext) { }

        public async Task AddMediaAsync(CourseMedium courseMedia)
        {
            await CreateAsync(courseMedia);
        }
    }
}
