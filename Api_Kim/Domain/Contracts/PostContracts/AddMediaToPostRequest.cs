using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.PostContracts
{
    public class AddMediaToPostRequest
    {
        public int FileId { get; set; }  // ID файла
        public int PostId { get; set; }  // ID поста, к которому привязывается файл
    }
}
