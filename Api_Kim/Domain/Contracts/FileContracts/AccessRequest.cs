using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.FileContracts
{
    public class AccessRequest
    {
        public int UserId { get; set; }
        public string AccessType { get; set; } // 'read', 'write', 'admin'
    }
}