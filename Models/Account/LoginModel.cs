using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password should be atleast 8 characters.")]
        public string password { get; set; }
        public bool isvalid { get; set; }
        public UserModel userdetails { get; set; }
        public FuncAccessModel funcAccess { get; set; }
        public AlertModel alert { get; set; }
    }
}
