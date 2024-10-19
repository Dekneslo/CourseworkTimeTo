using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            IdUsers = new HashSet<User>();
        }

        public int IdChatRoom { get; set; }
        public string NameRoom { get; set; } = null!;

        public virtual ICollection<User> IdUsers { get; set; }
    }
}
