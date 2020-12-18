using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CreatedModified
    {
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
    }
}
