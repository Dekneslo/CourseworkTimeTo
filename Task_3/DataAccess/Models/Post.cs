using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Post
    {
        public Post()
        {
            PostMedia = new HashSet<PostMedium>();
        }

        public int IdPost { get; set; }
        public int? IdUser { get; set; }
        public string? PostTitle { get; set; }
        public string? PostContent { get; set; }
        public DateTime? DatePosted { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<PostMedium> PostMedia { get; set; }
    }
}
