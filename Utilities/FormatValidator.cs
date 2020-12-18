using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utilities.Core;

namespace Utilities
{
    public enum CHARACTER_TYPE
    {
        ALPHANUMERIC = 0,
        NUMERIC = 1,
        ALPHA = 2
    }

    public class FormatValidator
    {
        public static bool IsAlpha(string Value)
        {
            return Regex.IsMatch(Value, "^[a-zA-Z]+$", RegexOptions.IgnoreCase);
        }

        public static bool IsAlphaNumeric(string Value)
        {
            return Regex.IsMatch(Value, "^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase);
        }

        public static bool IsNumber(string Value)
        {
            return Regex.IsMatch(Value, "^[0-9]+$", RegexOptions.IgnoreCase);
        }

        public static bool IsDate(string Value)
        {
            DateTime tempDate;
            if (DateTime.TryParse(Value, out tempDate))
            {
                return true;
            }

            return false;
        }

        public static bool IsWithBlacklistedCharacter(string Value)
        {
            if (!String.IsNullOrEmpty(Value))
            {
                var blackListedCharacter = new[] { "/", "<", ">", ";", ":", "'", "\"", "|", "[", "]", "{", "}", "(", ")", "\\" };
                return blackListedCharacter.Any(Value.Contains);
            }
            else
                return false;
        }

        public static bool IsValid(string Value, bool Required, CHARACTER_TYPE CharacterType)
        {
            if (Required)
            {
                if (Value.IsEmpty())
                {
                    return false;
                }
            }

            if (IsWithBlacklistedCharacter(Value))
            {
                return false;
            }

            if (CharacterType.Equals(CHARACTER_TYPE.NUMERIC))
            {
                if (!IsNumber(Value))
                {
                    return false;
                }
            }

            return true;
        }

        public static string FixMobileFormat(string Mobile)
        {
            if (Mobile.StartsWith("63"))
                Mobile = "0" + Mobile.Substring(2, Mobile.Length - 2);

            return Mobile;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
