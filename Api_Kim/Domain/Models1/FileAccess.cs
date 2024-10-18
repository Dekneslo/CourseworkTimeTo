using System;
using System.Collections.Generic;

namespace Domain.Models1
{
    public partial class FileAccess
    {
        public int IdFile { get; set; }
        public int IdUser { get; set; }
        public string AccessType { get; set; } = null!;

        public virtual File IdFileNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
