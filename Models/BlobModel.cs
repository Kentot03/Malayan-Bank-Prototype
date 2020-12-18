using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class BlobModel
    {
        public string filename { get; set; }
        public byte[] content { get; set; } 
        public string contentType { get; set; }
    }
}
