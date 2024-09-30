using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
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
                    .HasName("PK__AuditLog__3C7153CAD404EE03");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuditLog__idUser__797309D9");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Categori__79D361B63F4B6974");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(100)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.HasKey(e => e.IdChatRoom)
                    .HasName("PK__ChatRoom__77CA433CF4E3AEFC");

                entity.Property(e => e.IdChatRoom).HasColumnName("idChatRoom");

                entity.Property(e => e.NameRoom)
                    .HasMaxLength(100)
                    .HasColumnName("nameRoom");

                entity.HasMany(d => d.IdUsers)
                    .WithMany(p => p.IdChatRooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChatRoomUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ChatRoomU__idUse__5CD6CB2B"),
                        r => r.HasOne<ChatRoom>().WithMany().HasForeignKey("IdChatRoom").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ChatRoomU__idCha__5BE2A6F2"),
                        j =>
                        {
                            j.HasKey("IdChatRoom", "IdUser").HasName("PK__ChatRoom__44BB3FA42387E54A");

                            j.ToTable("ChatRoomUsers");

                            j.IndexerProperty<int>("IdChatRoom").HasColumnName("idChatRoom");

                            j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                        });
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__Comments__0370297ED3E13A79");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__idCour__60A75C0F");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__idUser__5FB337D6");
            });

            modelBuilder.Entity<CommentMedium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__CommentM__28E7F5734F3FDE32");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CommentMe__idCom__6477ECF3");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Courses__8982E309D2B71B88");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.NameCourse)
                    .HasMaxLength(100)
                    .HasColumnName("nameCourse");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__idCateg__4222D4EF");

                entity.HasOne(d => d.IdUserNavigation)
        .WithMany(p => p.Courses)
        .HasForeignKey(d => d.IdUser)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK__Courses__idUser__4316F928");

                // Настройка связи многие ко многим с пользователями
                entity.HasMany(d => d.IdUsers)
                    .WithMany(p => p.IdCourses)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsersCourse",
                        l => l.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("IdCourse").OnDelete(DeleteBehavior.ClientSetNull),
                        j =>
                        {
                            j.HasKey("IdUser", "IdCourse").HasName("PK__UsersCou__BF8FE7B2D114015B");
                            j.ToTable("UsersCourses");
                            j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                            j.IndexerProperty<int>("IdCourse").HasColumnName("idCourse");
                        });
            });

            modelBuilder.Entity<CourseMedium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__CourseMe__28E7F5731CD3FFC7");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseMed__idCou__45F365D3");
            });

            modelBuilder.Entity<DailyUpdate>(entity =>
            {
                entity.HasKey(e => e.IdUpdate)
                    .HasName("PK__DailyUpd__746286B67E0071DA");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DailyUpda__idUse__6D0D32F4");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PK__Files__775AFE7204FA4F12");

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
                    .HasConstraintName("FK__Files__idUser__4D94879B");
            });

            modelBuilder.Entity<FileAccess>(entity =>
            {
                entity.HasKey(e => new { e.IdFile, e.IdUser })
                    .HasName("PK__FileAcce__442B82EAA6A02880");

                entity.ToTable("FileAccess");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.AccessType)
                    .HasMaxLength(50)
                    .HasColumnName("accessType");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileAcces__idFil__5070F446");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileAcces__idUse__5165187F");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.IdLike)
                    .HasName("PK__Likes__1439B2464CFB2529");

                entity.Property(e => e.IdLike).HasColumnName("idLike");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK__Likes__idCourse__693CA210");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdFile)
                    .HasConstraintName("FK__Likes__idFile__68487DD7");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Likes__idUser__6754599E");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("PK__Messages__8D0E911D9B5F3D7A");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__idReci__5535A963");

                entity.HasOne(d => d.IdSenderNavigation)
                    .WithMany(p => p.MessageIdSenderNavigations)
                    .HasForeignKey(d => d.IdSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__idSend__5441852A");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Posts__BE0F4FD65CDE2D42");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__idUser__72C60C4A");
            });

            modelBuilder.Entity<PostMedium>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("PK__PostMedi__28E7F57349FDB128");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostMedia__idPos__76969D2E");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdProfile)
                    .HasName("PK__Profiles__E5A723F87824DFFA");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profiles__idUser__3D5E1FD2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__E5045C5430EA4D7B");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(50)
                    .HasColumnName("nameRole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__3717C982F8104F53");

                entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164B0C59288")
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__role__3A81B327");

                entity.HasMany(d => d.IdCourses)
                    .WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsersCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("IdCourse").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UsersCour__idCou__49C3F6B7"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UsersCour__idUse__48CFD27E"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdCourse").HasName("PK__UsersCou__BF8FE7B2D114015B");

                            j.ToTable("UsersCourses");

                            j.IndexerProperty<int>("IdUser").HasColumnName("idUser");

                            j.IndexerProperty<int>("IdCourse").HasColumnName("idCourse");
                        });
            });

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.Language })
                    .HasName("PK__UserLang__A9ED13DF6C03C2DC");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .HasColumnName("language");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserLanguages)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLangu__idUse__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
