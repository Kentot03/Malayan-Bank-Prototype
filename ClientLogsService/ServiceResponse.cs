using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogsService
{
    public class ServiceResponse<T>
    {
        public int ReturnCode { get; set; } = 200;
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public T Details { get; set; }
    }
}
