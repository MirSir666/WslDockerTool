using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Manage
{
     public static partial class StringHelper
    {

        public static bool IsEmpty(this string str)
        {
            return str.Length == 0;
        }

        /// <summary>
        /// Indicate if a string is null or empty.
        /// </summary>
        /// <returns>
        /// true if a null or is empty, false if not.
        /// </returns>
        /// <param name="str">The str to act on.</param>
        public static bool IsNullOrEmpty(this string str)
        {
            return ReferenceEquals(str, null) || str.Length == 0;
        }

        /// <summary>
        /// Set all first letter to upper case.
        /// </summary>
        /// <param name="str">The str to act on.</param>
        public static string Titleize(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// Split a string and remove empty lines.
        /// </summary>
        /// <returns>
        /// A string[].
        /// </returns>
        /// <param name="str">The str to act on.</param>
        /// <param name="separator">The separator.</param>
        public static string[] SplitNoEmptyLines(this string str, string separator)
        {
            return str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }


        /// <summary>
        /// Split a string and remove empty lines.
        /// </summary>
        /// <returns>
        /// A string[].
        /// </returns>
        /// <param name="str">The str to act on.</param>
        /// <param name="separator">The separator.</param>
        public static string[] SplitKeepEmptyLines(this string str, string separator)
        {
            return str.Split(separator, StringSplitOptions.None);
        }

        /// <summary>
        /// Split a string.
        /// </summary>
        /// <returns>
        /// A string[].
        /// </returns>
        /// <param name="str">The str to act on.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="stringSplitOptions">Options for controlling the operation.</param>
        public static string[] Split(this string str, string separator, StringSplitOptions stringSplitOptions)
        {
            return str.Split(new string[] { separator }, stringSplitOptions);
        }



    }
}
