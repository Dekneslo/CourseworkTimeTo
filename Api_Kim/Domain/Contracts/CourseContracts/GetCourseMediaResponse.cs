using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.CourseContracts
{
    public class GetCourseMediaResponse
    {
        public int MediaId { get; set; }
        public int CourseId { get; set; }
        public string FileName { get; set; }
        public string MediaType { get; set; }
    }
}
