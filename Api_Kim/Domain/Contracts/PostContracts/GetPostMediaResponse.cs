using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.PostContracts
{
    public class GetPostMediaResponse
    {
        public int MediaId { get; set; }
        public string FileName { get; set; }
        public string MediaType { get; set; }
    }
}
