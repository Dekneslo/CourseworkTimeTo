using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.UserContracts
{
    public class ChangeUserLanguageRequest
    {
        public int UserId { get; set; }
        public string LanguageCode { get; set; }
    }
}
