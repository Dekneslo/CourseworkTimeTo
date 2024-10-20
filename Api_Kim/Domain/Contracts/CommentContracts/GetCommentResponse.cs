using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CommentContracts
{
    public class GetCommentResponse
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime DateCommented { get; set; }
        public string UserName { get; set; }
    }
}
