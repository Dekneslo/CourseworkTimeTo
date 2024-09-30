using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.FileContracts
{
    public class UpdateFileRequest
    {
        public int IdFile { get; set; } // Идентификатор файла
        public string FileName { get; set; }
        public string FileType { get; set; }
        // Если требуется обновлять содержимое файла:
        public byte[] FileData { get; set; }
    }
}
