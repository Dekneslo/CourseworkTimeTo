using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class File
    {
        public File()
        {
            FileAccesses = new HashSet<FileAccess>();
            Likes = new HashSet<Like>();
        }

        public int IdFile { get; set; }
        public string? NameFile { get; set; }
        public string? FileType { get; set; }
        public long? FileSize { get; set; }
        public string? FilePath { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
