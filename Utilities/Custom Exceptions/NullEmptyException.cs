using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    [Serializable]
    public class NullEmptyException : Exception
    {
        public string ErrorCode { get; private set; }

        public NullEmptyException(string param, string errorCode)
           : base(String.Format("{0} is empty/null", param))
        {
            ErrorCode = errorCode;
        }

        public NullEmptyException(string param, string message, string errorCode)
            : base(String.Format("{0} {1}", param, message))
        {
            ErrorCode = errorCode;
        }
    }
}
