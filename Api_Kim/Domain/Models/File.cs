using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class File
    {
        public File()
        {
            CourseMedia = new HashSet<CourseMedium>();
            FileAccesses = new HashSet<FileAccess>();
            PostMedia = new HashSet<PostMedium>();
        }

        public int IdFile { get; set; }
        public string NameFile { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public long FileSize { get; set; }
        public string FilePath { get; set; } = null!;
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<CourseMedium> CourseMedia { get; set; }
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        public virtual ICollection<PostMedium> PostMedia { get; set; }
    }
}
