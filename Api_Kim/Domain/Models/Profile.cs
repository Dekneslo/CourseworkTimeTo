using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Profile
    {
        public int IdProfile { get; set; }
        public int? IdUser { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Biography { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}