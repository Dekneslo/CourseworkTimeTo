using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MessageDTO
    {
        public int IdMessage { get; set; }
        public int IdSender { get; set; }
        public int IdRecipient { get; set; }
        public string MessageText { get; set; }
        public DateTime SendingDatetime { get; set; }
    }
}
