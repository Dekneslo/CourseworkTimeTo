using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Course
    {
        public Course()
        {
            UsersCourses = new HashSet<UsersCourse>();
            Comments = new HashSet<Comment>();
            CourseMedia = new HashSet<CourseMedium>();
            LikesToCourses = new HashSet<LikesToCourse>();
            IdUsers = new HashSet<User>();
        }

        public int IdCourse { get; set; }
        public string NameCourse { get; set; } = null!;
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<UsersCourse> UsersCourses { get; set; }  
        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseMedium> CourseMedia { get; set; }
        public virtual ICollection<LikesToCourse> LikesToCourses { get; set; }

        public virtual ICollection<User> IdUsers { get; set; }
    }
}
