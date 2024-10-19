using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class PostMedium
    {
        public int IdMedia { get; set; }
        public int IdPost { get; set; }
        public int IdFile { get; set; }

        public virtual File IdFileNavigation { get; set; } = null!;
        public virtual Post IdPostNavigation { get; set; } = null!;
    }
}
