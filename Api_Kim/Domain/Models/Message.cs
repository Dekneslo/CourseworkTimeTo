﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Message
    {
        public int IdMessage { get; set; }
        public int IdSender { get; set; }
        public int IdRecipient { get; set; }
        public DateTime SendingDatetime { get; set; }
        public string MessageText { get; set; } = null!;

        public virtual User IdRecipientNavigation { get; set; } = null!;
        public virtual User IdSenderNavigation { get; set; } = null!;
    }
}
