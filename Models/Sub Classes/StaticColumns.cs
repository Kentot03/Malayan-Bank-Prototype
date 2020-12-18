using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class StaticColumns : CreatedModified
    {
        public string _id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required.")]
        [Display(Name = "Code")]
        public string code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string description { get; set; }
        public string status { get; set; }
    }
}
