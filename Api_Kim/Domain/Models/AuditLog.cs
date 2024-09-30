using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class AuditLog
    {
        public int IdLog { get; set; }
        public int? IdUser { get; set; }
        public string? Action { get; set; }
        public DateTime? DateAction { get; set; }
        public string? Description { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}