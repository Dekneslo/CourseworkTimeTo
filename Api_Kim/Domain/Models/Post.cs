using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            LikesToPosts = new HashSet<LikesToPost>();
            PostMedia = new HashSet<PostMedium>();
        }

        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public string PostTitle { get; set; } = null!;
        public string PostContent { get; set; } = null!;
        public DateTime DatePosted { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<LikesToPost> LikesToPosts { get; set; }
        public virtual ICollection<PostMedium> PostMedia { get; set; }
    }
}
