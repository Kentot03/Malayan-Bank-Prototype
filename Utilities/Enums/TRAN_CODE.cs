using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Enums
{
    public enum TRAN_CODE
    {
        [Description("USER")]
        USER,
        [Description("USER_GROUP")]
        UGRP,
        [Description("APPROVAL")]
        APRV
    }
}
