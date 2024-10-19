using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            DailyUpdates = new HashSet<DailyUpdate>();
            FileAccesses = new HashSet<FileAccess>();
            Files = new HashSet<File>();
            LikesToCourses = new HashSet<LikesToCourse>();
            LikesToPosts = new HashSet<LikesToPost>();
            MessageIdRecipientNavigations = new HashSet<Message>();
            MessageIdSenderNavigations = new HashSet<Message>();
            Posts = new HashSet<Post>();
            Profiles = new HashSet<Profile>();
            UserLanguages = new HashSet<UserLanguage>();
            IdChatRooms = new HashSet<ChatRoom>();
            IdCourses = new HashSet<Course>();
        }

        public int IdUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }

        public virtual Role RoleNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DailyUpdate> DailyUpdates { get; set; }
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<LikesToCourse> LikesToCourses { get; set; }
        public virtual ICollection<LikesToPost> LikesToPosts { get; set; }
        public virtual ICollection<Message> MessageIdRecipientNavigations { get; set; }
        public virtual ICollection<Message> MessageIdSenderNavigations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }

        public virtual ICollection<ChatRoom> IdChatRooms { get; set; }
        public virtual ICollection<Course> IdCourses { get; set; }
    }
}
