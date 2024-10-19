using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CourseMedium
    {
        public int IdMedia { get; set; }
        public int IdCourse { get; set; }
        public int IdFile { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual File IdFileNavigation { get; set; } = null!;
    }
}
