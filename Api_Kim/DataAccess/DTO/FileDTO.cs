using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class FileDTO
    {
        public int IdFile { get; set; }             
        public string NameFile { get; set; }       
        public string FileType { get; set; }        
        public long FileSize { get; set; }          
        public string FilePath { get; set; }        
        public int? IdUser { get; set; }            
    }
}
