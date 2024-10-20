using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CommentContracts
{
    public class CommentRequest
    {
        public int UserId { get; set; }  // ID пользователя, который оставляет комментарий
        public int? PostId { get; set; }  // ID поста (если это комментарий к посту)
        public int? CourseId { get; set; }  // ID курса (если это комментарий к курсу)
        public string CommentText { get; set; }  // Текст комментария
        public DateTime DateCommented { get; set; } = DateTime.Now;  // Дата комментария
    }
}
