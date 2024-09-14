using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class CharityDBContext : DbContext
    {
        public CharityDBContext()
        {
        }

        public CharityDBContext(DbContextOptions<CharityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ChatRoom> ChatRooms { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentMedium> CommentMedia { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseMedium> CourseMedia { get; set; } = null!;
        public virtual DbSet<DailyUpdate> DailyUpdates { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<FileAccess> FileAccesses { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostMedium> PostMedia { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLanguage> UserLanguages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__AuditLog__3C7153CA7DBAA916");

                entity.ToTable("AuditLog");

                entity.Property(e => e.IdLog).HasColumnName("idLog");

                entity.Property(e => e.Action)
                    .HasMaxLength(100)
                    .HasColumnName("action");

                entity.Property(e => e.DateAction)
                    .HasColumnType("datetime")
                    .HasColumnName("dateAction")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AuditLogs)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__AuditLog__idUser__66603565");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Categori__79D361B60F9645E2");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(100)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.HasKey(e => e.IdChatRoom)
                    .HasName("PK__ChatRoom__77CA433CBEB082DC");

                entity.Property(e => e.IdChatRoom).HasColumnName("idChatRoom");

                entity.Property(e => e.NameRoom)
                    .HasMaxLength(100)
                    .HasColumnName("nameRoom");

                entity.HasMany(d => d.IdUsers)
                    .WithMany(p => p.IdChatRooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChatRoomUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ChatRoomU__idUse__49C3F6B7"),
                        r => r.HasOne<ChatRoom>().WithMany().HasForeignKey("IdChatRoom").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ChatRoomU__idCha__48CFD27E"),
                        j =>
                        {
                            j.HasKey("IdChatRoom", "IdUser").HasName("PK__ChatRoom__44BB3FA406A0439E");

                            j.ToTable("ChatRoomUsers");

                            j.IndexerProperty<int>("IdChatRoom").HasColumnName("idChatRoom");

                            j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                        });
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__Comments__0370297E5F06D635");

                entity.Property(e => e.IdComment).HasColumnName("idComment");

                entity.Property(e => e.CommentDescription).HasColumnName("commentDescription");

                entity.Property(e => e.DateCommented)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCommented")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK__Comments__idCour__4D94879B");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Comments__idUser__4CA06362");
            });

            modelBuilder.Entity<CommentMedium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__CommentM__28E7F573F55FBA3B");

                entity.Property(e => e.IdMedia).HasColumnName("idMedia");

                entity.Property(e => e.IdComment).HasColumnName("idComment");

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(255)
                    .HasColumnName("mediaPath");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(10)
                    .HasColumnName("mediaType");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithMany(p => p.CommentMedia)
                    .HasForeignKey(d => d.IdComment)
                    .HasConstraintName("FK__CommentMe__idCom__5165187F");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Courses__8982E3096F66BF41");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NameCourse)
                    .HasMaxLength(100)
                    .HasColumnName("nameCourse");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Courses__idCateg__2F10007B");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Courses__idUser__300424B4");
            });

            modelBuilder.Entity<CourseMedium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__CourseMe__28E7F57357DF803B");

                entity.Property(e => e.IdMedia).HasColumnName("idMedia");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(255)
                    .HasColumnName("mediaPath");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(10)
                    .HasColumnName("mediaType");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.CourseMedia)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK__CourseMed__idCou__33D4B598");
            });

            modelBuilder.Entity<DailyUpdate>(entity =>
            {
                entity.HasKey(e => e.IdUpdate)
                    .HasName("PK__DailyUpd__746286B6E6811C85");

                entity.Property(e => e.IdUpdate).HasColumnName("idUpdate");

                entity.Property(e => e.DateOfPosted)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfPosted")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.DailyUpdates)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__DailyUpda__idUse__59FA5E80");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PK__Files__775AFE72DBA63402");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .HasColumnName("filePath");

                entity.Property(e => e.FileSize).HasColumnName("fileSize");

                entity.Property(e => e.FileType)
                    .HasMaxLength(50)
                    .HasColumnName("fileType");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NameFile)
                    .HasMaxLength(255)
                    .HasColumnName("nameFile");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Files__idUser__3A81B327");
            });

            modelBuilder.Entity<FileAccess>(entity =>
            {
                entity.HasKey(e => new { e.IdFile, e.IdUser })
                    .HasName("PK__FileAcce__442B82EAD589C4AE");

                entity.ToTable("FileAccess");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.AccessType)
                    .HasMaxLength(50)
                    .HasColumnName("accessType");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileAcces__idFil__3D5E1FD2");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__FileAcces__idRol__3F466844");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileAcces__idUse__3E52440B");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.IdLike)
                    .HasName("PK__Likes__1439B2468DE09528");

                entity.Property(e => e.IdLike).HasColumnName("idLike");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK__Likes__idCourse__5629CD9C");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdFile)
                    .HasConstraintName("FK__Likes__idFile__5535A963");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Likes__idUser__5441852A");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("PK__Messages__8D0E911DF14A330A");

                entity.Property(e => e.IdMessage).HasColumnName("idMessage");

                entity.Property(e => e.IdRecipient).HasColumnName("idRecipient");

                entity.Property(e => e.IdSender).HasColumnName("idSender");

                entity.Property(e => e.MessageText).HasColumnName("messageText");

                entity.Property(e => e.SendingDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("sendingDatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdRecipientNavigation)
                    .WithMany(p => p.MessageIdRecipientNavigations)
                    .HasForeignKey(d => d.IdRecipient)
                    .HasConstraintName("FK__Messages__idReci__4316F928");

                entity.HasOne(d => d.IdSenderNavigation)
                    .WithMany(p => p.MessageIdSenderNavigations)
                    .HasForeignKey(d => d.IdSender)
                    .HasConstraintName("FK__Messages__idSend__4222D4EF");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Posts__BE0F4FD64918186E");

                entity.Property(e => e.IdPost).HasColumnName("idPost");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasColumnName("datePosted")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.PostContent).HasColumnName("postContent");

                entity.Property(e => e.PostTitle)
                    .HasMaxLength(255)
                    .HasColumnName("postTitle");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Posts__idUser__5FB337D6");
            });

            modelBuilder.Entity<PostMedium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__PostMedi__28E7F57338292B07");

                entity.Property(e => e.IdMedia).HasColumnName("idMedia");

                entity.Property(e => e.IdPost).HasColumnName("idPost");

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(255)
                    .HasColumnName("mediaPath");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(10)
                    .HasColumnName("mediaType");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.PostMedia)
                    .HasForeignKey(d => d.IdPost)
                    .HasConstraintName("FK__PostMedia__idPos__6383C8BA");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdProfile)
                    .HasName("PK__Profiles__E5A723F8D33F2313");

                entity.Property(e => e.IdProfile).HasColumnName("idProfile");

                entity.Property(e => e.Biography).HasColumnName("biography");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phoneNumber");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Profiles__idUser__2A4B4B5E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__E5045C549A4A7C4D");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(50)
                    .HasColumnName("nameRole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__3717C9824F493E0A");

                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61641A5E9D94")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK__Users__role__276EDEB3");

                entity.HasMany(d => d.IdCourses)
                    .WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsersCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("IdCourse").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UsersCour__idCou__37A5467C"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UsersCour__idUse__36B12243"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdCourse").HasName("PK__UsersCou__BF8FE7B2B1655DF6");

                            j.ToTable("UsersCourses");

                            j.IndexerProperty<int>("IdUser").HasColumnName("idUser");

                            j.IndexerProperty<int>("IdCourse").HasColumnName("idCourse");
                        });
            });

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.Language })
                    .HasName("PK__UserLang__A9ED13DF6AC33323");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .HasColumnName("language");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserLanguages)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLangu__idUse__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
