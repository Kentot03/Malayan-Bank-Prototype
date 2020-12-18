using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AlertModel
    {
        public bool Show { get; set; }
        public string MessageType { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
    }
}
