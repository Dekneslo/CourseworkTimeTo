using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CommentMedium
    {
        public int IdMedia { get; set; }
        public int? IdComment { get; set; }
        public string? MediaType { get; set; }
        public string? MediaPath { get; set; }

        public virtual Comment? IdCommentNavigation { get; set; }
    }
}