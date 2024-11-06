using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.PostContracts
{
    public class GetDailyUpdateResponse
    {
        public int IdUpdate { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPosted { get; set; }
        public string UserName { get; set; }
    }
}
