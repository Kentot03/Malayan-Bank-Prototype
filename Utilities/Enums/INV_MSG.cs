using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Enums
{
    public enum INV_MSG
    {
        [Description("Invalid Session ID Format.")]
        SESSION,
        [Description("Internal server error occured")]
        SERVER_ERROR = 500,
        [Description("Invalid Device ID Format")]
        DEVICE
    }
}
