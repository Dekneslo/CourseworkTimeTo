using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class FileAccess
    {
        public int IdFile { get; set; }
        public int IdUser { get; set; }
        public int? IdRole { get; set; }
        public string? AccessType { get; set; }

        public virtual File IdFileNavigation { get; set; } = null!;
        public virtual Role? IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
