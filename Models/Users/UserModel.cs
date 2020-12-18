using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class UserModel : CreatedModified
    {
        public string _id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string employee_no { get; set; }
        public string usergroup_id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string user_name { get; set; }
        public string password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string first_name { get; set; }
        public string middle_name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string last_name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string birth_date { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string email_address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string contact_no { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string store_code { get; set; }
        public string status { get; set; }
        public string status_user_code { get; set; }
    }

    public class UserViewModel : UserModel
    {
        public string usergroup_name { get; set; }
        public string store_name { get; set; }
    }

    public class UserInfoModel
    {
        public UserModel User { get; set; }
        public UserControlModel UserControl { get; set; }
    }
}

