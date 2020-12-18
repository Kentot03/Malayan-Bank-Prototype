using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class LoginResult
    {
        public LoginResult()
        {
            userdetails = new user();
            //funcAccess = new colfuncAccess();
        }

        public bool isvalid { get; set; }
        public user userdetails { get; set; }
        //public colfuncAccess funcAccess { get; set; }

    }
}
