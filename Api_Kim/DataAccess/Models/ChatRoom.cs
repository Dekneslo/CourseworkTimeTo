using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            IdUsers = new HashSet<User>();
        }

        public int IdChatRoom { get; set; }
        public string? NameRoom { get; set; }

        public virtual ICollection<User> IdUsers { get; set; }
    }
}
