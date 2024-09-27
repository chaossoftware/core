using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChaosSoft.Core.IO;

/// <summary>
/// The reader reads source file as serialized double[][] object.
/// </summary>
public class BinaryDataFileReader : IDataReader
{
    /// <summary>
    /// Reads source data file as serialized double[][]. If the file exists it will be overwritten.
    /// </summary>
    /// <param name="source">path to file to read</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public double[][] ReadColumnsFromFile(string source)
    {
        if (!File.Exists(source))
        {
            throw new FileNotFoundException("Source data file not found.", source);
        }

        byte[] bytes = File.ReadAllBytes(source);

        using MemoryStream ms = new(bytes);
        ms.Seek(0, 0);
        return (double[][]) new BinaryFormatter().Deserialize(ms);
    }
}
