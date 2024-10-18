using System;
using System.Collections.Generic;

namespace Domain.Models1
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
