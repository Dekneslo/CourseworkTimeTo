using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentMedia = new HashSet<CommentMedium>();
        }

        public int IdComment { get; set; }
        public int? IdUser { get; set; }
        public int? IdCourse { get; set; }
        public string? CommentDescription { get; set; }
        public DateTime? DateCommented { get; set; }

        public virtual Course? IdCourseNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<CommentMedium> CommentMedia { get; set; }
    }
}
