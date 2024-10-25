using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CommentContracts
{
    public class UpdateCommentRequest
    {
        public string CommentText { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
