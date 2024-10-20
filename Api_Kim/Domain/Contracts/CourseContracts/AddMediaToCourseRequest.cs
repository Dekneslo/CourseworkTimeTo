using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CourseContracts
{
    public class AddMediaToCourseRequest
    {
        public int FileId { get; set; }  // ID файла, который будет привязан к курсу
        public int CourseId { get; set; }
    }
}
