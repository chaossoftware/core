using System.Globalization;
using System.Linq;

namespace ChaosSoft.Core;

/// <summary>
/// Provides with helpers for formatting.
/// </summary>
public static class NumFormat
{
    // To avoid format generation each time for more performance at least for default formats.
    private const int DefaultPrecision = 7;
    private const string DefaultGeneralFormat = "G7";
    private const string DefaultCustomFormat = "0.#######";

    private static readonly CultureInfo DefaultCulture = CultureInfo.InvariantCulture;

    /// <summary>
    /// Gets or sets currently used number format (default 0.#######).
    /// </summary>
    public static string CurrentFormat { get; set; } = DefaultCustomFormat;

    /// <summary>
    /// Gets or sets currently used culture info (default InvariantCulture)
    /// </summary>
    public static CultureInfo CurrentCulture { get; set; } = DefaultCulture;

    /// <summary>
    /// Gets general (G) format with currently specified precision.
    /// </summary>
    public static string General { get; private set; } = DefaultGeneralFormat;

    /// <summary>
    /// Gets custom (0.##...) format with currently specified precision.
    /// </summary>
    public static string FixPointTrimZeros { get; private set; } = DefaultCustomFormat;

    /// <summary>
    /// Resets format configuration to defaults.
    /// </summary>
    public static void Reset()
    {
        CurrentFormat = DefaultCustomFormat;
        CurrentCulture = DefaultCulture;
        SetPrecision(DefaultPrecision);
    }

    /// <summary>
    /// Resets format configuration to defaults.
    /// </summary>
    public static void SetPrecision(int precision)
    {
        General = $"G{precision}";
        FixPointTrimZeros = $"0.{new string('#', precision)}";
    }

    /// <summary>
    /// Formats double value in specified format using current culture info.
    /// </summary>
    /// <param name="value">value to format</param>
    /// <param name="format">number format</param>
    /// <returns></returns>
    public static string Format(double value, string format) =>
        value.ToString(format, CurrentCulture);

    /// <summary>
    /// Formats double value in specified format using current culture info and current format.
    /// </summary>
    /// <param name="value">value to format</param>
    /// <returns></returns>
    public static string Format(double value) =>
        Format(value, CurrentFormat);

    /// <summary>
    /// Formats double value in specified format using current culture info and current format.
    /// </summary>
    /// <param name="value">value to format</param>
    /// <returns></returns>
    public static string Format(double[] value) =>
        Format(value, CurrentFormat, "; ");

    /// <summary>
    /// Formats array of double values using current format and specified delimiter.
    /// </summary>
    /// <param name="values">values to format</param>
    /// <param name="delimiter">values delimiter</param>
    /// <returns></returns>
    public static string Format(double[] values, string delimiter) =>
        Format(values, CurrentFormat, delimiter);

    /// <summary>
    /// Formats array of double values using specified format and delimiter.
    /// </summary>
    /// <param name="values">values to format</param>
    /// <param name="format">number format</param>
    /// <param name="delimiter">values delimiter</param>
    /// <returns></returns>
    public static string Format(double[] values, string format, string delimiter) =>
        string.Join(delimiter, values.Select(v => v.ToString(format, CurrentCulture)));
}
