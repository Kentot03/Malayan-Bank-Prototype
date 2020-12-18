using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LoginResultModel
    {
        public bool isvalid { get; set; }
        public UserModel userdetails { get; set; }
        public UserControlModel userControl { get; set; }
        public List<FuncAccessModel> funcAccess { get; set; }
        public bool hasSecurityQuestions { get; set; }
    }
}
