using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ClientLogsModel
    {
        public string ID { get; set; }
        public DateTime Log_Date { get; set; }
        public string User_ID { get; set; }
        public string IPAddress { get; set; }
        public string Device { get; set; }
        public string Module { get; set; }
        public string Remarks { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
