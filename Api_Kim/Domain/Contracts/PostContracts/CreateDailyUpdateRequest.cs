using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.PostContracts
{
    public class CreateDailyUpdateRequest
    {
        public string Description { get; set; }
        public int IdUser { get; set; }
        public DateTime? DateOfPosted { get; set; }
    }
}
