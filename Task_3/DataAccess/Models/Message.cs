using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Message
    {
        public int IdMessage { get; set; }
        public int? IdSender { get; set; }
        public int? IdRecipient { get; set; }
        public DateTime? SendingDatetime { get; set; }
        public string? MessageText { get; set; }

        public virtual User? IdRecipientNavigation { get; set; }
        public virtual User? IdSenderNavigation { get; set; }
    }
}
