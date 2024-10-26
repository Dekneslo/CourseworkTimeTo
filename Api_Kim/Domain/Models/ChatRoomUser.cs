using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class ChatRoomUser
    {
        public int IdChatRoom { get; set; }
        public int idUser { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
        public virtual User User { get; set; }
    }
}
