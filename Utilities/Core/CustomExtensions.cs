using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities.Core
{
    public enum RangeCheck { Exclusive, Inclusive }

    public static class CustomExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static string GetDescription(this Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch
            {
                throw new Exception("Unable to get description.");
            }
        }
        public static String SHA512(this String Input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(Input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.AsString();
            }
        }

        public static Object GetPropValue(this Object obj, String propName)
        {
            string[] nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
                return obj.GetType().GetProperty(propName).GetValue(obj, null);
            }

            foreach (String part in nameParts)
            {
                if (obj == null)
                { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null)
                { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        #region Math Utilities

        public static Boolean IsInteger(this String number)
        {
            /* Double.TryParse is used so num values with a larger range than Int64 can be handled. */
            Double _ = 0.0;
            return Double.TryParse(number, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out _);
        }

        public static Boolean IsDouble(this String number)
        {
            Double _ = 0.0;
            return Double.TryParse(number, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out _);
        }

        public static int AsInt(this Object value)
        {
            try
            {
                if (value == null)
                    return 0;
                else
                    return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static Int64 AsInt64(this Object value)
        {
            try
            {
                if (value == null)
                    return 0;
                else
                    return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }

        public static Decimal AsDecimal(this Object value)
        {
            try
            {
                if (value == null)
                    return 0;
                else
                    return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }

        private static void CheckBase(Int32 _base /* "base" is a keyword in C#, hence the leading underscore. */)
        {
            if (!_base.IsInRange(2, 36))
                throw new ArgumentOutOfRangeExceptionFmt("The parameter 'toBase' has an illegal value of {0}.  toBase must be between 2 and 36, inclusive.", _base);
        }

        public static String ToBase(this Int32 number, Int32 toBase)
        {
            return Convert.ToInt64(number).ToBase(toBase);
        }

        public static String ToBase(this Int64 number, Int32 toBase)
        {
            CheckBase(toBase);

            var digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, toBase);
            var result = "";

            while (number > 0)
            {
                var digitValue = (Int32)(number % (Double)toBase);
                number /= toBase;
                result = digits.Substring(digitValue, 1) + result;
            }

            return result;
        }

        public static Int32 FromBase(this String otherBaseNumber, Int32 fromBase)
        {
            CheckBase(fromBase);

            var digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, fromBase);
            var result = 0;

            otherBaseNumber = otherBaseNumber.ToUpper();

            for (Int32 i = 0; i < otherBaseNumber.Length; i++)
            {
                var digitValue = digits.IndexOf(otherBaseNumber.Substring(i, 1), 0, digits.Length);

                if (digitValue < 0)
                    throw new ArgumentException(String.Format("The parameter 'otherBaseNumber' ({0}) contains digits that are not valid for the parameter 'fromBase' {1}.", otherBaseNumber, fromBase));

                result = (result * fromBase) + digitValue;
            }

            return result;
        }

        public static String FromBaseToBase(this String number, Int32 fromBase, Int32 toBase)
        {
            return number.FromBase(fromBase).ToBase(toBase).TrimStart("0".ToCharArray());
        }

        public static void Swap(ref Int32 number1, ref Int32 number2)
        {
            var temp = number1;
            number1 = number2;
            number2 = temp;
        }

        public static Boolean IsInRange(this Int32 value, Int32 min, Int32 max)
        {
            return value.IsInRange(min, max, RangeCheck.Inclusive);
        }

        public static Boolean IsInRange(this Int32 value, Int32 min, Int32 max, RangeCheck rangeCheck)
        {
            if (min > max)
                throw new ArgumentOutOfRangeExceptionFmt("The parameter 'min' ({0}) is greater than the parameter 'max' ({1}).", min, max);

            switch (rangeCheck)
            {
                case RangeCheck.Exclusive:
                    return ((value > min) && (value < max));
                case RangeCheck.Inclusive:
                    return ((value >= min) && (value <= max));
                default:
                    throw new ArgumentOutOfRangeExceptionFmt("Unknown RangeCheck value ({0}).", rangeCheck);
            }
        }

        #endregion

        #region DateTime Utilities
        public static DateTime AsDateTime(this Object Value, String Format)
        {
            DateTime date = new DateTime();
            try
            {
                if (Value == null)
                    return date;
                else
                    return Convert.ToDateTime(Value);
            }
            catch
            {
                return date;
            }
        }

        public static String AsDateTimeString(this Object Value, String Format)
        {
            try
            {
                if (Value == null)
                    return String.Empty;
                else
                    return Convert.ToDateTime(Value).ToString(Format);
            }
            catch
            {
                return String.Empty;
            }
        }
        #region Quarter Methods
        public static Int32 Quarter(this DateTime dateTime)
        {
            return ((dateTime.Month + 2) / 3);
        }

        public static DateTime AddQuarters(this DateTime dateTime, Int32 quarters)
        {
            return dateTime.AddMonths(quarters * 3);
        }

        private static void CheckQuarter(Int32 quarter)
        {
            if ((quarter < 1) || (quarter > 4))
                throw new ArgumentExceptionFmt("A quarter of {0} is not valid. quarter must be between 1 and 4 inclusive.", quarter);
        }

        public static DateTime GetFirstDayOfQuarter(Int32 year, Int32 quarter)
        {
            CheckQuarter(quarter);
            return (new DateTime(year, 1, 1)).AddQuarters(quarter - 1);
        }

        public static DateTime FirstDayOfQuarter(this DateTime dateTime)
        {
            return (new DateTime(dateTime.Year, 1, 1)).AddQuarters(dateTime.Quarter() - 1);
        }

        public static DateTime GetLastDayOfQuarter(Int32 year, Int32 quarter)
        {
            CheckQuarter(quarter);
            return (new DateTime(year, 1, 1)).AddQuarters(quarter).AddDays(-1);
        }

        public static DateTime LastDayOfQuarter(this DateTime dateTime)
        {
            return (new DateTime(dateTime.Year, 1, 1)).AddQuarters(dateTime.Quarter()).AddDays(-1);
        }

        public static Boolean AreDatesInSameYearAndQuarter(DateTime dateTime1, DateTime dateTime2)
        {
            return (dateTime1.FirstDayOfQuarter() == dateTime2.FirstDayOfQuarter());
        }

        public static Boolean IsDateInYearAndQuarter(DateTime dateTime, Int32 year, Int32 quarter)
        {
            CheckQuarter(quarter);
            return ((dateTime.Year == year) && (dateTime.Quarter() == quarter));
        }
        #endregion

        public static DateTime Min(DateTime dateTime1, DateTime dateTime2)
        {
            return (dateTime1 < dateTime2) ? dateTime1 : dateTime2;
        }

        public static DateTime Max(DateTime dateTime1, DateTime dateTime2)
        {
            return (dateTime1 > dateTime2) ? dateTime1 : dateTime2;
        }

        /* endDateTime can be earlier, the same, or later than startDateTime.

           If both parameters are the same date, then a list with one DateTime element
           is returned, and the element's value is the same as startDateTime (and endDateTime).

           If endDateTime is later than startDateTime, then an ascending list of DateTimes
           is returned.  Likewise, if endDateTime is earlier than startDateTime, a descending
           list of DateTimes is returned.

           For example:

             var time1 = new DateTime(2000, 1, 1);
             var time2 = new DateTime(2000, 1, 3);

             Calling time1.To(time2) will return a list
             of DateTimes in ascending order:

               1/1/2000
               1/2/2000
               1/3/2000

             The reverse call to time2.To(time1) will
             return a descending list of DateTimes:

               1/3/2000
               1/2/2000
               1/1/2000
        */

        public static IEnumerable<DateTime> To(this DateTime startDateTime, DateTime endDateTime)
        {
            var signedNumberOfDays = (endDateTime - startDateTime).Days;
            var sign = (signedNumberOfDays < 0) ? -1 : 1;
            var absoluteNumberOfDays = Math.Abs(signedNumberOfDays) + 1; /* "+ 1" to ensure both the start and end dates are included in the result set. */
            var result = new List<DateTime>(absoluteNumberOfDays);

            for (var day = 0; day < absoluteNumberOfDays; day++)
                result.Add(startDateTime.AddDays(day * sign));

            return result;
        }
        #endregion

        #region String Utilities
        public static String AsString(this Object Value)
        {
            try
            {
                if (Value == null)
                    return String.Empty;
                else
                    return Value.ToString();
            }
            catch
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// Case insensitive version of System.String.IndexOf().
        /// </summary>
        public static Int32 IndexOfCI(this String source, String searchValue)
        {
            source.Name("source").NotNull();
            searchValue.Name("searchValue").NotNull();
            return source.IndexOf(searchValue, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Case insensitive version of System.String.Contains().
        /// </summary>
        public static Boolean ContainsCI(this String source, String searchValue)
        {
            source.Name("source").NotNull();
            searchValue.Name("searchValue").NotNull();
            return (source.IndexOfCI(searchValue) > -1);
        }

        /// <summary>
        /// Return 'value' repeated 'count' times.
        /// <para>
        /// <ul>
        ///   <li>Value cannot be null</li>
        ///   <li>A count of zero or a negative count returns an empty string</li>
        ///   <li>A count of one returns value.</li>
        ///   <li>A count of more than one returns value repeated count times.</li>
        ///   <li>If (value.Length * count) > Int32.Max, an OverflowException is thrown.</li>
        /// </ul>
        /// </para>
        /// </summary>
        public static String Repeat(this String value, Int32 count)
        {
            value.Name("value").NotNull();
            return (count < 1) ? "" : (new StringBuilder(value.Length * count)).Insert(0, value, count).ToString();
        }

        /// <summary>
        /// Returns true if value is in the set "1,Y,T,TRUE,YES" (case insensitive).
        /// </summary>
        public static Boolean AsBoolean(this String value)
        {
            String chars = "1,Y,T,TRUE,True,YES,y,t,true,yes,SUCCESS,success";

            return (!String.IsNullOrEmpty(value)) && chars.Contains(value.Trim());
        }

        /// <summary>
        /// Return the last Char in 'value'.
        /// <para>
        /// 'value' must be non-null and contain one or more characters.
        /// </para>
        /// </summary>
        public static Char LastChar(this String value)
        {
            value.Name("value").NotNull().NotEmpty();
            return value[value.Length - 1];
        }

        /// <summary>
        /// Return the last word - separated by a space character - in 'value'.
        /// <para>
        /// 'value' must be non-null and contain one or more characters.
        /// </para>
        /// </summary>
        public static String LastWord(this String value)
        {
            value.Name("value").NotNull().NotEmpty();
            var lastIndexOfSpace = value.Trim().LastIndexOf(' ');
            return (lastIndexOfSpace == -1) ? value : value.Substring(lastIndexOfSpace + 1);
        }

        /// <summary>
        /// Returns 'value' with 'c' pre-pended and appended.
        /// <para>
        /// Both 'value' and 'c' must be non-null.
        /// </para>
        /// </summary>
        public static String SurroundWith(this String value, String c)
        {
            return value.SurroundWith(c, c);
        }

        /// <summary>
        /// Returns 'value' with 'c1' pre-pended and 'c2' appended.
        /// <para>
        /// All parameters must be non-null.
        /// </para>
        /// </summary>
        public static String SurroundWith(this String value, String c1, String c2)
        {
            value.Name("value").NotNull();
            c1.Name("c1").NotNull();
            c2.Name("c2").NotNull();
            return String.Concat(c1, value, c2);
        }

        public static String SingleQuote(this String value)
        {
            return value.SurroundWith("'");
        }

        public static String DoubleQuote(this String value)
        {
            return value.SurroundWith("\"");
        }

        public static String SquareBrackets(this String value)
        {
            return value.SurroundWith("[", "]");
        }

        /// <summary>
        /// Remove 'prefix' from the beginning of 'value' and return the result.
        /// <para>
        /// Both 'value' and 'prefix' must be non-null.
        /// </para>
        /// </summary>
        public static String RemovePrefix(this String value, String prefix)
        {
            value.Name("value").NotNull();
            prefix.Name("prefix").NotNull();

            if (value.StartsWith(prefix, StringComparison.CurrentCulture))
                return value.Substring(prefix.Length);
            else
                return value;
        }

        /// <summary>
        /// Remove 'suffix' from the end of 'value' and return the result.
        /// <para>
        /// Both 'value' and 'suffix' must be non-null.
        /// </para>
        /// </summary>
        public static String RemoveSuffix(this String value, String suffix)
        {
            value.Name("value").NotNull();
            suffix.Name("suffix").NotNull();

            if ((suffix.Length <= value.Length) && (value.EndsWith(suffix, StringComparison.CurrentCulture)))
                return value.Substring(0, value.Length - suffix.Length);
            else
                return value;
        }

        /// <summary>
        /// Remove 'stringToTrim' from the beginning and end of 'value' and return the result.
        /// <para>
        /// Both 'value' and 'stringToTrim' must be non-null.
        /// </para>
        /// </summary>
        public static String RemovePrefixAndSuffix(this String value, String stringToTrim)
        {
            return value.RemovePrefix(stringToTrim).RemoveSuffix(stringToTrim);
        }

        private static readonly Regex _whitespaceRegex = new Regex(@"[\p{Z}\p{C}]" /* All Unicode whitespace (Z) and control characters (C). */, RegexOptions.Singleline);

        /// <summary>
        /// Remove all Unicode whitespace from 'value' and return the modified string.
        /// <para>
        /// 'value' must be non-null.
        /// </para>
        /// </summary>
        public static String RemoveWhitespace(this String value)
        {
            value.Name("value").NotNull();
            return _whitespaceRegex.Replace(value, "");
        }

        /// <summary>
        /// Returns true if 'value' is null, has a length of zero, or contains only whitespace.
        /// <para>
        /// 'value' must be non-null.
        /// </para>
        /// </summary>
        public static Boolean IsEmpty(this String value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Returns true if 'value' is not null, has a length greater than zero, and does not consist of only whitespace.
        /// <para>
        /// 'value' must be non-null.
        /// </para>
        /// </summary>
        public static Boolean IsNotEmpty(this String value)
        {
            return !value.IsEmpty();
        }

        /// <summary>
        /// Returns true if all strings in 'values' are null, have a length of zero, or contain only whitespace.
        /// <para>
        /// 'values' must be non-null.
        /// </para>
        /// </summary>
        public static Boolean AreAllEmpty(this List<String> values)
        {
            values.Name("values").NotNull();
            return values.All(s => s.IsEmpty());
        }

        /// <summary>
        /// Returns true if any of the strings in 'values' are null, have a length of zero, or contain only whitespace.
        /// <para>
        /// 'values' must be non-null.
        /// </para>
        /// </summary>
        public static Boolean AreAnyEmpty(this List<String> values)
        {
            values.Name("values").NotNull();
            return values.Any(s => s.IsEmpty());
        }

        private static readonly Regex _indentTextRegex = new Regex("(\r\n|\n)");

        /// <summary>
        /// Treat 'value' as a multiline string, where each string is separated either by
        /// a carriage return/linefeed combo, or just a linefeed.
        /// <para>
        /// Indent each line in 'value' by 'indent' spaces and return the modified string.
        /// </para>
        /// <para>
        /// 'value' must be non-null, and 'indent' must be greater than zero.
        /// </para>
        /// </summary>
        public static String Indent(this String value, Int32 indent)
        {
            value.Name("value").NotNull();
            indent.Name("indent").GreaterThan(0);

            var indentString = " ".Repeat(indent);
            return indentString + _indentTextRegex.Replace(value, "$1" + indentString);
        }

        /// <summary>
        /// Case-insensitive version of System.String.Equals().
        /// </summary>
        public static Boolean EqualsCI(this String value, String other)
        {
            value.Name("value").NotNull();
            other.Name("other").NotNull();
            return value.Equals(other, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Case-insensitive version of !System.String.Equals().
        /// </summary>
        public static Boolean NotEqualsCI(this String value, String other)
        {
            return !value.EqualsCI(other);
        }

        /// <summary>
        /// Case-insensitive version of System.String.StartsWith().
        /// </summary>
        public static Boolean StartsWithCI(this String value, String other)
        {
            value.Name("value").NotNull();
            other.Name("other").NotNull();
            return value.StartsWith(other, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion
    }

    public class CaseInsensitiveStringComparer : IEqualityComparer<String>
    {
        public static CaseInsensitiveStringComparer Instance = new CaseInsensitiveStringComparer();

        public Int32 GetHashCode(String s)
        {
            return s.GetHashCode();
        }

        public Boolean Equals(String s1, String s2)
        {
            return s1.EqualsCI(s2);
        }
    }
}
