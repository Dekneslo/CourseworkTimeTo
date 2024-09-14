using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            Comments = new HashSet<Comment>();
            CourseMedia = new HashSet<CourseMedium>();
            Likes = new HashSet<Like>();
            IdUsers = new HashSet<User>();
        }

        public int IdCourse { get; set; }
        public string? NameCourse { get; set; }
        public string? Description { get; set; }
        public int? IdCategory { get; set; }
        public int? IdUser { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseMedium> CourseMedia { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<User> IdUsers { get; set; }
    }
}
