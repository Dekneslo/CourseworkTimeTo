
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class PostDTO
    {
        public int IdPost { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
    }
}
