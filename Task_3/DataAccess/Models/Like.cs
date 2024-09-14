using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Like
    {
        public int IdLike { get; set; }
        public int? IdUser { get; set; }
        public int? IdFile { get; set; }
        public int? IdCourse { get; set; }

        public virtual Course? IdCourseNavigation { get; set; }
        public virtual File? IdFileNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
