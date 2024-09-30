using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CourseDTO
    {
        public int IdCourse { get; set; }
        public string NameCourse { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
