using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    [Serializable]
    public class UserStatusException : Exception
    {
        public string ErrorCode { get; private set; }

        public UserStatusException(string param, string errorCode)
           : base(String.Format("User account is {0}. Please contact your administrator.", param))
        {
            ErrorCode = errorCode;
        }

        public UserStatusException(string message, string errorCode, string param = null)
           : base(String.Format("{0} is expired. Please contact your administrator.", message))
        {
            ErrorCode = errorCode;
        }
    }
}
