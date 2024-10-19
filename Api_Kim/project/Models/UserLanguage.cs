using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserLanguage
    {
        public int IdUser { get; set; }
        public string Language { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
