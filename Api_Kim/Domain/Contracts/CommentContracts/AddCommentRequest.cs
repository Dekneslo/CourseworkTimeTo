using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CommentContracts
{
    public class AddCommentRequest
    {
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        public string CommentText { get; set; }
    }
}
