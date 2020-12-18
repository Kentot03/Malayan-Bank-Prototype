using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Response<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Details { get; set; }
    }
}
