using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ChaosSoft.Core.IO;

/// <summary>
/// Provides with methods for reading of data files with timeseries.
/// </summary>
public class PlainTextFileReader : IDataReader
{
    /// <summary>
    /// Default regex for column delimiter ("\s+")
    /// </summary>
    public const string DefaultDelimiterRegex = "\\s+";

    private readonly int _skipLines;
    private readonly int _readLines;
    private readonly string _delimiterRegex;

    /// <summary>
    /// Initializes a new instance of <see cref="PlainTextFileReader"/> configured to read whole file 
    /// using <see cref="DefaultDelimiterRegex"/>
    /// </summary>
    public PlainTextFileReader() : this(0, 0, DefaultDelimiterRegex)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PlainTextFileReader"/> configured to skip specified count of lines 
    /// from the beginning and to read rest of file using <see cref="DefaultDelimiterRegex"/>
    /// </summary>
    /// <param name="skipLines">count of lines to skip from the beginning</param>
    public PlainTextFileReader(int skipLines) : this(skipLines, 0, DefaultDelimiterRegex)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PlainTextFileReader"/> configured to read specified range from file 
    /// using <see cref="DefaultDelimiterRegex"/>.
    /// </summary>
    /// <param name="skipLines">count of lines to skip from the beginning</param>
    /// <param name="readLines">count of lines to read</param>
    public PlainTextFileReader(int skipLines, int readLines) : this(skipLines, readLines, DefaultDelimiterRegex)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PlainTextFileReader"/> configured to read specified range from file 
    /// using specified columns delimiter regex.
    /// </summary>
    /// <param name="skipLines">count of lines to skip from the beginning</param>
    /// <param name="readLines">count of lines to read</param>
    /// <param name="delimiterRegex">regex of columns delimiter</param>
    public PlainTextFileReader(int skipLines, int readLines, string delimiterRegex)
    {
        _skipLines = skipLines;
        _readLines = readLines;
        _delimiterRegex = delimiterRegex;
    }

    /// <summary>
    /// Reads file from specific path and gets specified data range from the file using column delimiter regex.
    /// </summary>
    /// <param name="file">path to file to read</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="InvalidDataException"></exception>
    public double[][] ReadColumnsFromFile(string file)
    {
        if (!File.Exists(file))
        {
            throw new FileNotFoundException("Source data file not found.", file);
        }

        int i, j;

        string[] sourceData = File.ReadAllLines(file);

        // Determine how many numbers in line.
        int columns = Regex.Split(sourceData[_skipLines].Trim(), _delimiterRegex).Length;

        int length = _readLines == 0 ? sourceData.Length - _skipLines : _readLines;

        double[][] dataColumns = new double[columns][];

        for (i = 0; i < dataColumns.Length; i++)
        {
            dataColumns[i] = new double[length];
        }

        for (i = _skipLines; i < length + _skipLines; i++)
        {
            var numbers = Regex.Split(sourceData[i].Trim(), _delimiterRegex);

            for (j = 0; j < columns; j++)
            {
                if (double.TryParse(numbers[j], NumberStyles.Any, NumFormat.CurrentCulture, out double value))
                {
                    dataColumns[j][i - _skipLines] = value;
                }
                else
                {
                    throw new InvalidDataException(
                        $"Unable to parse value (Line: {i + 1}, Column: {j + 1} [value: {numbers[j]}])");
                }
            }
        }

        return dataColumns;
    }
}
