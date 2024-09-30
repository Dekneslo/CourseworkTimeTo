using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CourseMedium
    {
        public int IdMedia { get; set; }
        public int? IdCourse { get; set; }
        public string? MediaType { get; set; }
        public string? MediaPath { get; set; }

        public virtual Course? IdCourseNavigation { get; set; }
    }
}