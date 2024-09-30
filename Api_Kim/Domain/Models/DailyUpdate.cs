using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class DailyUpdate
    {
        public int IdUpdate { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfPosted { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}