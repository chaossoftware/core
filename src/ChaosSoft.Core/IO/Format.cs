using System.Globalization;
using System.Linq;

namespace ChaosSoft.Core.IO
{
    /// <summary>
    /// Provides with helpers for formatting.
    /// </summary>
    public static class Format
    {
        internal const string Default = "G6";

        /// <summary>
        /// Formats double value in general format (G6).
        /// </summary>
        /// <param name="value">value to format</param>
        /// <returns></returns>
        public static string General(double value) =>
            value.ToString(Default, CultureInfo.InvariantCulture);

        /// <summary>
        /// Formats double value in general format with specific digits count.
        /// </summary>
        /// <param name="value">value to format</param>
        /// <param name="digits">significant digits to display</param>
        /// <returns></returns>
        public static string General(double value, int digits) =>
            value.ToString("G" + digits, CultureInfo.InvariantCulture);

        /// <summary>
        /// Formats array of double values in general format (G6) with '; ' delimiter.
        /// </summary>
        /// <param name="values">values to format</param>
        /// <returns></returns>
        public static string General(double[] values) =>
            General(values, "; ", 6);

        /// <summary>
        /// Formats array of double values in general format with specific digits count and delimiter.
        /// </summary>
        /// <param name="values">values to format</param>
        /// <param name="delimiter">values delimiter</param>
        /// <param name="digits">significant digits to display</param>
        /// <returns></returns>
        public static string General(double[] values, string delimiter, int digits) =>
            string.Join(delimiter, values.Select(v => General(v, digits)));
    }
}
