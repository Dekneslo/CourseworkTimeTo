using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CourseContracts
{
    public class CommentRequest
    {
        public int UserId { get; set; }
        public string CommentText { get; set; }
    }
}
