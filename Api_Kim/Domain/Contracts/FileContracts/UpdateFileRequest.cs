﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.FileContracts
{
    public class UpdateFileRequest
    {
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        // Если требуется обновлять содержимое файла:
        public string FilePath { get; set; }
    }
}
