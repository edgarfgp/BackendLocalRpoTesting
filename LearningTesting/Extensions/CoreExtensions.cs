using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LearningTesting.Extensions
{
    public static class CoreExtensions
    {
        //Object

        /// <summary>
        /// Check if the value of the object is null.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>true if the object value is null.</returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Check if the value of the object is not null.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>true if the object value is not null.</returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// Check if the value of the object is not default.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>true if the object value is not default.</returns>
        public static bool IsNotDefault(this object obj)
        {
            return obj != default(object);
        }

        /// <summary>
        /// Check if the value is the object default value.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>true if the object value is his type default.</returns>
        public static bool IsDefault(this object obj)
        {
            return obj == default(object);
        }

        /// <summary>
        /// Checks if the object is null and if the output of his derive ToString returns empty.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>true if the object is null or his ToString returns empty string.</returns>
        public static bool IsNullOrToStringEmpty(this object obj)
        {
            return obj.IsNull() ? true :
                obj.ToString().IsEmpty();
        }
        /// <summary>
        /// Checks if the object is null and if the output of his derive ToString returns empty.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>true if the object is not null and his ToString returns different than empty string.</returns>
        public static bool IsNotNullOrToStringEmpty(this object obj)
        {
            return !obj.IsNotNullOrToStringEmpty();
        }

        //Csv valid values.

        /// <summary>
        /// Converts a GUID to a string valid as a value on a CSV file.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>return a valid CSV value string with the content of the GUID.</returns>
        public static string ToCsvValidString(this Guid me)
        {
            return me.ToStringOrEmpty().RemoveEOL().RemoveCommas();
        }

        /// <summary>
        /// Converts a string to a string valid as a value on a CSV file.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>return a valid CSV value string with the content of the string.</returns>
        public static string ToCsvValidString(this string me)
        {
            return me.ToStringOrEmpty().RemoveEOL().RemoveCommas();
        }

        /// <summary>
        /// Converts a DateTime to a string valid as a value on a CSV file.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>return a valid CSV value string with the content of the DateTime.</returns>
        public static string ToCsvValidString(this DateTime? me)
        {
            return me.ToStringOrEmpty().RemoveEOL().RemoveCommas();
        }

        /// <summary>
        /// Converts a INT to a string valid as a value on a CSV file.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>return a valid CSV value string with the content of the INT.</returns>
        public static string ToCsvValidString(this int me)
        {
            return me.ToString().RemoveEOL().RemoveCommas();
        }

        //String

        /// <summary>
        /// Checks if two strings are Equal. 
        /// </summary>
        /// <param name="me">Compare to.</param>
        /// <param name="other">Compare with.</param>
        /// <returns>true if both strings are equal.</returns>
        /// <remarks>This extensions supersedes the <see cref="string.Equals(object)"/> by checking if they are null.</remarks>
        public static bool AreEqual(this string me, string other)
        {
            if (me.IsNull() && other.IsNull())
                return true;

            if (me.IsNull())
                return false;

            return me.Equals(other);
        }

        /// <summary>
        /// Check if the string is null or empty.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the string is null or empty.</returns>
        public static bool IsEmpty(this string me)
        {
            return string.IsNullOrWhiteSpace(me);
        }

        /// <summary>
        /// Check if the string is not null and not empty.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the string is not null and not empty.</returns>
        public static bool IsNotEmpty(this string me)
        {
            return !me.IsEmpty();
        }

        /// <summary>
        /// Converts a string to a not null string.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>Always return a string. The same string or an empty string is input string is null.</returns>
        public static string ToStringOrEmpty(this string me)
        {
            return me.IsNull() ? string.Empty : me.ToString();
        }

        /// <summary>
        /// Removes the End of lines from given string.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>Returns the string without the End of lines.</returns>
        public static string RemoveEOL(this string me)
        {
            return me.Replace("\n\r", " ").Replace('\n', ' ');
        }

        /// <summary>
        /// Remove commas from a given string.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>return he same string without commas.</returns>
        /// <remarks>To be used formating CSV file content as a CSV file values of headers may not contain commas.</remarks>
        public static string RemoveCommas(this string me)
        {
            return me.Replace(',', ' ');
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> if the value is null or empty.
        /// </summary>
        /// <param name="me">Target string.</param>
        /// <param name="attribName">Name of the attribute</param>
        public static void ThrowOnEmpty(this string me, string attribName)
        {
            if (me.IsEmpty())
            {
                throw new ArgumentNullException("String may not be empty.", attribName);
            }
        }

        //GUID

        /// <summary>
        /// Checks if a given string contains a valid GUID and not empty.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the given GUID is not valid or <see cref="Guid.Empty"/></returns>
        public static bool IsGuidEmpty(this string me)
        {
            return string.IsNullOrEmpty(me);
        }

        /// <summary>
        /// Return the opposite to <see cref="IsGuidEmpty(string)"/>
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the given GUID is valid and not <see cref="Guid.Empty"/></returns>
        public static bool IsNotGuidEmpty(this string me)
        {
            return !me.IsGuidEmpty();
        }

        /// <summary>
        /// Check for valid GUID and not <see cref="Guid.Empty"/>
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the given GUID is null or <see cref="Guid.Empty"/></returns>
        public static bool IsGuidEmpty(this Guid me)
        {
            return me.Equals(default);
        }

        /// <summary>
        /// Return the opposite to <see cref="IsGuidEmpty(Guid)"/>
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the given GUID is not null, valid and not <see cref="Guid.Empty"/></returns>
        public static bool IsNotGuidEmpty(this Guid me)
        {
            return !me.IsGuidEmpty();
        }

        /// <summary>
        /// check for a valid <see cref="Guid"/>
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the input string contains a valid <see cref="Guid"/></returns>
        public static bool IsValidGuid(this string me)
        {
            return Guid.TryParse(me, out Guid dummy);
        }

        /// <summary>
        /// Opposite to <see cref="IsValidGuid(string)"/>
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>true if the given string does not contain a valid <see cref="Guid"/></returns>
        public static bool IsNotValidGuid(this string me)
        {
            return !me.IsValidGuid();
        }

        /// <summary>
        /// Converts a GUID To a valid string with the content of the <see cref="Guid"/> or an empty string.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>return a valid string with the <see cref="Guid"/> value or an empty string.</returns>
        public static string ToStringOrEmpty(this Guid me)
        {
            return me.IsGuidEmpty() ? string.Empty : me.ToString();
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> if the value is null or empty.
        /// </summary>
        /// <param name="me">Target <see cref="Guid"/></param>
        /// <param name="attribName"></param>
        public static void ThrowOnEmpty(this Guid me, string attribName)
        {
            if (me.IsGuidEmpty())
            {
                throw new ArgumentNullException("Attribute may not be empty.", attribName);
            }
        }

        //Lists

        /// <summary>
        /// check if the provided <see cref="List{Object}"/> is null or empty.
        /// </summary>
        /// <param name="list">Target <see cref="List{Object}"/></param>
        /// <returns>try if the <see cref="List{Object}"/> is null or empty</returns>
        public static bool IsListNullOrEmpty(this List<Object> list)
        {
            if (list == null)
                return true;

            return list.Count == 0;
        }

        /// <summary>
        /// Check if the provided <see cref="IEnumerable{Object}"/> is null or empty.
        /// </summary>
        /// <param name="list">Target <see cref="IEnumerable{Object}"/></param>
        /// <returns>try if the <see cref="IEnumerable{Object}"/> is null or empty</returns>
        public static bool IsEnumNullOrEmpty(this IEnumerable<object> list)
        {
            if (list == null)
                return true;

            return list.Count() == 0;
        }

        /// <summary>
        /// Check if the provided <see cref="List{Guid}"/> is null or empty.
        /// </summary>
        /// <param name="list">Target <see cref="List{Guid}"/></param>
        /// <returns>try if the <see cref="List{Guid}"/> is null or empty</returns>
        public static bool IsListNullOrEmpty(this List<Guid> list)
        {
            if (list == null)
                return true;

            return list.Count == 0;
        }

        /// <summary>
        /// Check if the provided <see cref="IEnumerable{Guid}"/> is null or empty.
        /// </summary>
        /// <param name="list">Target <see cref="IEnumerable{Guid}"/></param>
        /// <typeparam name="T">Object type.</typeparam>
        /// <returns>try if the <see cref="IEnumerable{Guid}"/> is null or empty</returns>
        public static bool IsEnumNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return true;

            return list.Count() == 0;
        }

        /// <summary>
        /// Return a int with the number of elements in the <see cref="IEnumerable{Object}"/>
        /// </summary>
        /// <param name="list">Target <see cref="IEnumerable{Object}"/></param>
        /// <returns>If <see cref="IEnumerable{Object}"/> is null return 0 or the Count.</returns>
        public static int CountIfNotNull(this IEnumerable<object> list)
        {
            if (list == null)
                return 0;

            return list.Count(); ;
        }

        /// <summary>
        /// Return a int with the number of elements in the <see cref="List{Object}"/>
        /// </summary>
        /// <param name="list">Target <see cref="List{Object}"/></param>
        /// <returns>If <see cref="List{Object}"/> is null return 0 or the Count.</returns>
        public static int CountIfNotNull(this List<object> list)
        {
            if (list == null)
                return 0;

            return list.Count(); ;
        }

        /// <summary>
        /// Return a int with the number of elements in the <see cref="IEnumerable{Guid}"/>
        /// </summary>
        /// <param name="list">Target <see cref="IEnumerable{Guid}"/></param>
        /// <returns>If <see cref="IEnumerable{Guid}"/> is null return 0 or the Count.</returns>
        public static int CountIfNotNull(this IEnumerable<Guid> list)
        {
            if (list == null)
                return 0;

            return list.Count(); ;
        }
        /// <summary>
        /// Return a int with the number of elements in the <see cref="List{Guid}"/>
        /// </summary>
        /// <param name="list">Target <see cref="List{Guid}"/></param>
        /// <returns>If <see cref="List{Guid}"/> is null return 0 or the Count.</returns>
        public static int CountIfNotNull(this List<Guid> list)
        {
            if (list == null)
                return 0;

            return list.Count(); ;
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> if the value is null or empty.
        /// </summary>
        /// <param name="me">Target object./></param>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="attribName">Name of the attribute.</param>
        public static void ThrowOnEmpty<T>(this IEnumerable<T> me, string attribName)
        {
            if (me.IsEnumNullOrEmpty())
            {
                throw new ArgumentNullException("Attribute may not be empty.", attribName);
            }
        }

        //Date

        /// <summary>
        /// Return the <see cref="DateTime"/> with the same date but starting time of the day.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns><see cref="DateTime"/> object with the same date but starting time.</returns>
        public static DateTime ToStartOfDay(this DateTime me)
        {
            return me.Date;
        }

        /// <summary>
        /// Return the <see cref="DateTime"/> with the same date but ending time. 1 millisecond before the next day.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns><see cref="DateTime"/> object with the same date but ending time.</returns>
        public static DateTime ToEndOfDay(this DateTime me)
        {
            return me.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Convert a string with a date on Reverse date format (yyyyMMdd) to a <see cref="DateTime"/>object.
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>A valid <see cref="DateTime"/> object.</returns>
        public static DateTime ToDateFromReverseDate(this string me)
        {
            return DateTime.ParseExact(me, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a string representing a date in Reverse date format.
        /// </summary>
        /// <param name="me">Seeding date.</param>
        /// <returns>string with a date in yyyyMMdd format.</returns>
        public static string ToReverseDateFromDate(this DateTime me)
        {
            return me.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Return a string representing the input <see cref="DateTime"/>
        /// </summary>
        /// <param name="me">Target object.</param>
        /// <returns>Valid string. Empty if the date it null, otherwise the date in string format.</returns>
        public static string ToStringOrEmpty(this DateTime? me)
        {
            return me.IsNull() || me == default ? string.Empty : me.ToString();
        }

        public static T CloneBySerialization<T>(this T source)
        {
            //REFERENCE : http://stackoverflow.com/questions/78536/deep-cloning-objects

            var serialized = JsonConvert.SerializeObject(source);
            var ret = JsonConvert.DeserializeObject<T>(serialized);
            return ret;
        }
    }
}
