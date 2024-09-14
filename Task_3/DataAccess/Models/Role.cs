using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            FileAccesses = new HashSet<FileAccess>();
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string? NameRole { get; set; }

        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
