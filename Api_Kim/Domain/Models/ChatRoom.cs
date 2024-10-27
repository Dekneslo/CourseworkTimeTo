using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            ChatRoomUsers = new HashSet<ChatRoomUser>();
        }

        public int IdChatRoom { get; set; }
        public string NameRoom { get; set; }

        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
    }
}
