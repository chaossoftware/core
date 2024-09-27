using System.Text;

namespace ChaosSoft.Core.IO;

/// <summary>
/// Writes double[,] data to a file.
/// </summary>
public class PlainTextFileWriter : IDataWriter<double[,]>
{
    private const string ColumnDelimiter = "\t";
    private readonly string _format;

    /// <summary>
    /// Initializes a new instance of <see cref="PlainTextFileWriter"/> with <see cref="NumFormat.CurrentFormat"/>
    /// </summary>
    public PlainTextFileWriter() : this(NumFormat.CurrentFormat)
    {

    }

    /// <summary>
    /// Initializes a new instance of <see cref="PlainTextFileWriter"/> with specified number format.
    /// </summary>
    /// <param name="format">number format</param>
    public PlainTextFileWriter(string format)
    {
        _format = format;
    }

    /// <summary>
    /// Create source data file and writes multidimensional array into it. If the file exists it will be overwritten.
    /// </summary>
    /// <param name="destination">path to file to create</param>
    /// <param name="data">data to write</param>
    public void WriteData(string destination, double[,] data)
    {
        var output = new StringBuilder();

        for (int i = 0; i < data.GetLength(1); i++)
        {
            for (int j = 0; j < data.GetLength(0); j++)
            {
                if (j > 0)
                {
                    output.Append(ColumnDelimiter);
                }

                output.Append(data[j, i].ToString(_format, NumFormat.CurrentCulture));
            }

            output.AppendLine();
        }

        FileUtils.CreateDataFile(destination, output.ToString());
    }
}
