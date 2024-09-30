using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.UserContracts
{
    public class ChangeUserPasswordRequest
    {
        public int IdUser { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
