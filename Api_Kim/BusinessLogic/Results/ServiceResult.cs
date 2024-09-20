using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Results
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public object Data { get; set; } 
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public object User { get; set; }

        public static ServiceResult SuccessResult(string message, object data = null)
        {
            return new ServiceResult { Success = true, Message = message, Data = data };
        }

        public static ServiceResult ErrorResult(string message)
        {
            return new ServiceResult { Success = false, Message = message };
        }
    }
}
