using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class FunctionalityModel : CreatedModified
    {
        public string _id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required.")]
        public string code { get; set; }
        public string module_code { get; set; }
        public string function_description { get; set; }
        public string system_code { get; set; }
        public string status { get; set; }
        public bool has_access { get; set; }
    }
}
