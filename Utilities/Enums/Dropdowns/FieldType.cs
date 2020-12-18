using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Utilities.Enums.Dropdowns
{
    public enum FieldType
    {
        [Display(Name = "Text")]
        TEXT = 1,
        [Display(Name = "Password")]
        PASSWORD = 2,
        [Display(Name = "Text Area")]
        TEXTAREA = 3,
        [Display(Name = "Display")]
        DISPLAY = 4,
        [Display(Name = "Email")]
        EMAIL = 5
    }
}
