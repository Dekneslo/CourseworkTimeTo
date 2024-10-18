using System;
using System.Collections.Generic;

namespace Domain.Models1
{
    public partial class PostMedium
    {
        public int IdMedia { get; set; }
        public int IdPost { get; set; }
        public string MediaType { get; set; } = null!;
        public string MediaPath { get; set; } = null!;

        public virtual Post IdPostNavigation { get; set; } = null!;
    }
}
