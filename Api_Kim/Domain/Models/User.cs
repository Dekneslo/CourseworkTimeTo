using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            AuditLogs = new HashSet<AuditLog>();
            Comments = new HashSet<Comment>();
            Courses = new HashSet<Course>();
            DailyUpdates = new HashSet<DailyUpdate>();
            FileAccesses = new HashSet<FileAccess>();
            Files = new HashSet<File>();
            Likes = new HashSet<Like>();
            MessageIdRecipientNavigations = new HashSet<Message>();
            MessageIdSenderNavigations = new HashSet<Message>();
            Posts = new HashSet<Post>();
            Profiles = new HashSet<Profile>();
            UserLanguages = new HashSet<UserLanguage>();
            IdChatRooms = new HashSet<ChatRoom>();
            IdCourses = new HashSet<Course>();
        }

        public int IdUser { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }

        public virtual Role? RoleNavigation { get; set; }
        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<DailyUpdate> DailyUpdates { get; set; }
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Message> MessageIdRecipientNavigations { get; set; }
        public virtual ICollection<Message> MessageIdSenderNavigations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }

        public virtual ICollection<ChatRoom> IdChatRooms { get; set; }
        public virtual ICollection<Course> IdCourses { get; set; }
    }
}
