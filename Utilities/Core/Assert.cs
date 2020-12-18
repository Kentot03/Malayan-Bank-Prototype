using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilities.Core
{
    [Flags]
    public enum StringAssertion
    {
        None = 0x1,
        NotNull = 0x2,
        NotOnlyWhitespace = 0x4,
        NotZeroLength = 0x8,
        All = NotNull | NotOnlyWhitespace | NotZeroLength
    }

    public static partial class AssertUtils
    {
        public static AssertionContext<T> Name<T>(this T source, String name)
        {
            return (new AssertionContext<T>(source)).Name(name);
        }

        public static AssertionContext<T> Name<T>(this AssertionContext<T> source, String name)
        {
            source.Name = name;
            return source;
        }

        public static AssertionContext<String> NotOnlyWhitespace(this String source)
        {
            return (new AssertionContext<String>(source)).NotOnlyWhitespace();
        }

        public static AssertionContext<String> NotOnlyWhitespace(this AssertionContext<String> source)
        {
            if (source.Value.Trim() != "")
                return source;
            else
                throw new ArgumentException("The string consists soley of whitespace.");
        }

        public static AssertionContext<String> NotNullEmptyOrOnlyWhitespace(this String source)
        {
            return (new AssertionContext<String>(source)).NotNullEmptyOrOnlyWhitespace();
        }

        public static AssertionContext<String> NotNullEmptyOrOnlyWhitespace(this AssertionContext<String> source)
        {
            return source.NotNull().NotEmpty().NotOnlyWhitespace();
        }

        public static AssertionContext<T> NotNull<T>(this T source)
          where T : class
        {
            return (new AssertionContext<T>(source)).NotNull();
        }

        public static AssertionContext<T> NotNull<T>(this AssertionContext<T> source)
          where T : class
        {
            if (source.Value != null)
                return source;
            else
                throw new ArgumentNullException(source.Name);
        }

        public static AssertionContext<T> NotEmpty<T>(this T source)
          where T : IEnumerable
        {
            return (new AssertionContext<T>(source)).NotEmpty();
        }

        public static AssertionContext<T> NotEmpty<T>(this AssertionContext<T> source)
          where T : IEnumerable
        {
            /* Some non-generic IEnumerator enumerators returned by IEnumerable.GetEnumerator()
               implement IDisposable, while others do not.  Those enumerators
               that do implement IDisposable will need to have their Dispose() method called.

               A non-generic IEnumerator cannot be used in a "using" statement.
               So to make sure Dispose() is called (if it exists), "foreach" is used
               because it will generate code to dispose of the IEnumerator
               if the enumerator also implements IDisposable. */

            /* This loop will execute zero or more times,
               and the foreach will dispose the enumerator, if necessary. */
            foreach (var _ in source.Value)
                return source; /* Loop executed once.  There is at least one element in the IEnumerable, which means it's not empty. */

            /* Loop executed zero times, which means the IEnumerable is empty. */
            throw new ArgumentException("The parameter is empty.");
        }

        public static AssertionContext<T> GreaterThan<T>(this T source, T value)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).GreaterThan(value);
        }

        public static AssertionContext<T> GreaterThan<T>(this AssertionContext<T> source, T value)
          where T : IComparable<T>
        {
            if (source.Value.CompareTo(value) > 0)
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not greater than '{2}'.", source.Name, source.Value, value));
        }

        public static AssertionContext<T> GreaterThanOrEqualTo<T>(this T source, T value)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).GreaterThanOrEqualTo(value);
        }

        public static AssertionContext<T> GreaterThanOrEqualTo<T>(this AssertionContext<T> source, T value)
          where T : IComparable<T>
        {
            if (source.Value.CompareTo(value) >= 0)
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not greater than or equal to '{2}'.", source.Name, source.Value, value));
        }

        public static AssertionContext<T> LessThan<T>(this T source, T value)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).LessThan(value);
        }

        public static AssertionContext<T> LessThan<T>(this AssertionContext<T> source, T value)
          where T : IComparable<T>
        {
            if (source.Value.CompareTo(value) < 0)
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not less than '{2}'.", source.Name, source.Value, value));
        }

        public static AssertionContext<T> LessThanOrEqualTo<T>(this T source, T value)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).LessThanOrEqualTo(value);
        }

        public static AssertionContext<T> LessThanOrEqualTo<T>(this AssertionContext<T> source, T value)
          where T : IComparable<T>
        {
            if (source.Value.CompareTo(value) <= 0)
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not less than or equal to '{2}'.", source.Name, source.Value, value));
        }

        public static AssertionContext<T> EqualTo<T>(this T source, T value)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).EqualTo(value);
        }

        public static AssertionContext<T> EqualTo<T>(this AssertionContext<T> source, T value)
          where T : IComparable<T>
        {
            if (source.Value.CompareTo(value) == 0)
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not equal to '{2}'.", source.Name, source.Value, value));
        }

        public static AssertionContext<T> NotEqualTo<T>(this T source, T value)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).NotEqualTo(value);
        }

        public static AssertionContext<T> NotEqualTo<T>(this AssertionContext<T> source, T value)
          where T : IComparable<T>
        {
            if (source.Value.CompareTo(value) != 0)
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is equal to '{2}'.", source.Name, source.Value, value));
        }

        public static AssertionContext<T> BetweenInclusive<T>(this T source, T lowerBound, T upperBound)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).BetweenInclusive(lowerBound, upperBound);
        }

        public static AssertionContext<T> BetweenInclusive<T>(this AssertionContext<T> source, T lowerBound, T upperBound)
          where T : IComparable<T>
        {
            if ((source.Value.CompareTo(lowerBound) >= 0) && (source.Value.CompareTo(upperBound) <= 0))
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not between '{2}' and '{3}' (exclusive).", source.Name, source.Value, lowerBound, upperBound));
        }

        public static AssertionContext<T> BetweenExclusive<T>(this T source, T lowerBound, T upperBound)
          where T : IComparable<T>
        {
            return (new AssertionContext<T>(source)).BetweenExclusive(lowerBound, upperBound);
        }

        public static AssertionContext<T> BetweenExclusive<T>(this AssertionContext<T> source, T lowerBound, T upperBound)
          where T : IComparable<T>
        {
            if ((source.Value.CompareTo(lowerBound) > 0) && (source.Value.CompareTo(upperBound) < 0))
                return source;
            else
                throw new ArgumentException(String.Format("The parameter '{0}', which has value '{1}', is not between '{2}' and '{3}' (exclusive).", source.Name, source.Value, lowerBound, upperBound));
        }

        public static AssertionContext<String> DirectoryExists(this String source)
        {
            return (new AssertionContext<String>(source)).DirectoryExists();
        }

        public static AssertionContext<String> DirectoryExists(this AssertionContext<String> source)
        {
            if (Directory.Exists(source.Value))
                return source;
            else
                throw new ArgumentException(String.Format("The string parameter '{0}' specifies directory '{1}' which does not exist.", source.Name, source.Value));
        }

        public static AssertionContext<String> FileExists(this String source)
        {
            return (new AssertionContext<String>(source)).FileExists();
        }

        public static AssertionContext<String> FileExists(this AssertionContext<String> source)
        {
            if (File.Exists(source.Value))
                return source;
            else
                throw new ArgumentException(String.Format("The string parameter '{0}' specifies file '{1}' which does not exist.", source.Name, source.Value));
        }
    }

    public class AssertionContext<T>
    {
        public String Name { get; set; }
        public T Value { get; set; }

        private AssertionContext()
          : base()
        {
        }

        public AssertionContext(T value)
          : this()
        {
            this.Name = "<Unknown variable name>";
            this.Value = value;
        }

        public AssertionContext(String name, T value)
          : this()
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
