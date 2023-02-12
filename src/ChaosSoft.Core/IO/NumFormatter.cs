using System.Globalization;

namespace ChaosSoft.Core.IO
{
    public static class NumFormatter
    {
        private const string Long = "G15";
        private const string Short = "0.#####";
        private const string Scientific = "e";

        public static string ToCustom(double number, string format) =>
            number.ToString(format, CultureInfo.InvariantCulture);

        public static string ToShort(double number) =>
            number.ToString(Short, CultureInfo.InvariantCulture);

        public static string ToLong(double number) =>
            number.ToString(Long, CultureInfo.InvariantCulture);

        public static string ToScientific(double number) =>
            number.ToString(Scientific, CultureInfo.InvariantCulture);
    }
}
