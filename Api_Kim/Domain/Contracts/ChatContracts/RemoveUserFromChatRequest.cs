using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.ChatContracts
{
    public class RemoveUserFromChatRequest
    {
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
    }
}
