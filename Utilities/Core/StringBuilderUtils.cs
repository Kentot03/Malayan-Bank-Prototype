using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core
{
    public static class StringBuilderUtils
    {
        public static StringBuilder AppendLineFormat(this StringBuilder sb, String format, params Object[] args)
        {
            sb.AppendFormat(format, args);
            sb.AppendLine();
            return sb;
        }
    }
}
