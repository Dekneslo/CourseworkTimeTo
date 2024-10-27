using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.MediaContracts
{
    public class UploadMediaRequest
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
    }
}
