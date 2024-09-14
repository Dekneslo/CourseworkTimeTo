using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserLanguage
    {
        public int IdUser { get; set; }
        public string Language { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
