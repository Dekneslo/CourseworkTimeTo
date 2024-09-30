using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.UserContracts
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
