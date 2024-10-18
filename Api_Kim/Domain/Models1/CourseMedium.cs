using System;
using System.Collections.Generic;

namespace Domain.Models1
{
    public partial class CourseMedium
    {
        public int IdMedia { get; set; }
        public int IdCourse { get; set; }
        public string MediaType { get; set; } = null!;
        public string MediaPath { get; set; } = null!;

        public virtual Course IdCourseNavigation { get; set; } = null!;
    }
}
