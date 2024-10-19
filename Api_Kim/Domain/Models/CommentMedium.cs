using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CommentMedium
    {
        public int IdMedia { get; set; }
        public int IdComment { get; set; }
        public string MediaType { get; set; } = null!;
        public string MediaPath { get; set; } = null!;

        public virtual Comment IdCommentNavigation { get; set; } = null!;
    }
}
