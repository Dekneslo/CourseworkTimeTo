using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CourseContracts
{
    public class EnrollCourseRequest
    {
        public int IdCourse { get; set; }
        public int IdUser { get; set; }
    }
}
