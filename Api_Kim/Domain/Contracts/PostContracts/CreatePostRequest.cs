using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.PostContracts
{
    public class CreatePostRequest
    {
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime DatePosted { get; set; }
        public int IdUser { get; set; }//?
    }
}
