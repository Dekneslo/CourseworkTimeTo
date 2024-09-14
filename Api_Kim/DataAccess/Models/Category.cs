using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int IdCategory { get; set; }
        public string? NameCategory { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
