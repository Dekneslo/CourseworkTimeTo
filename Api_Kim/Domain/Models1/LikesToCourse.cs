using System;
using System.Collections.Generic;

namespace Domain.Models1
{
    public partial class LikesToCourse
    {
        public int IdLike { get; set; }
        public int IdUser { get; set; }
        public int IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
