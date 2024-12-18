﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentMedia = new HashSet<CommentMedium>();
        }

        public int IdComment { get; set; }
        public int IdUser { get; set; }
        public int? IdPost { get; set; }
        public int? IdCourse { get; set; }
        public string CommentDescription { get; set; } = null!;
        public DateTime DateCommented { get; set; }

        public virtual Course? IdCourseNavigation { get; set; }
        public virtual Post? IdPostNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<CommentMedium> CommentMedia { get; set; }
    }
}
