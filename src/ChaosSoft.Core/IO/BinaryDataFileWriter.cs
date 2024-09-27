using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChaosSoft.Core.IO;

/// <summary>
/// Serializes double[][] data to a file.
/// </summary>
public class BinaryDataFileWriter : IDataWriter<double[][]>
{
    /// <summary>
    /// Create source data file and serialize object[][] data into it.
    /// </summary>
    /// <param name="destination">path to file to create</param>
    /// <param name="data">data to serialize</param>
    public void WriteData(string destination, double[][] data)
    {
        using MemoryStream ms = new();

        new BinaryFormatter().Serialize(ms, data);
        byte[] bytes = ms.ToArray();

        using FileStream fs = new(destination, FileMode.Create);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }
}
