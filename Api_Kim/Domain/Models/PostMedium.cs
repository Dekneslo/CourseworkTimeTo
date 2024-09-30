using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class PostMedium
    {
        public int IdMedia { get; set; }
        public int? IdPost { get; set; }
        public string? MediaType { get; set; }
        public string? MediaPath { get; set; }

        public virtual Post? IdPostNavigation { get; set; }
    }
}