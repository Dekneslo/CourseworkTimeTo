using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.FileContracts
{
    public class GetFileResponse
    {
        public int IdFile { get; set; }
        public string NameFile { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public int IdUser { get; set; }
    }
}
