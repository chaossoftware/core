using System.IO;
using System.Text;

namespace ChaosSoft.Core.IO;

/// <summary>
/// Contains utilities to work with file.
/// </summary>
public static class FileUtils
{
    /// <summary>
    /// Creates file with specific name and string data. If the file exists it will be overwritten.
    /// </summary>
    /// <param name="fileName">file name to create</param>
    /// <param name="data">string data to write</param>
    public static void CreateDataFile(string fileName, string data) =>
        CreateDataFile(fileName, data, new UTF8Encoding(true));

    /// <summary>
    /// Creates file with specific name and string data. If the file exists it will be overwritten.
    /// </summary>
    /// <param name="fileName">file name to create</param>
    /// <param name="data">string data to write</param>
    /// <param name="encoding">file encoding</param>
    public static void CreateDataFile(string fileName, string data, Encoding encoding)
    {
        File.Delete(fileName);
        FileStream outFile = File.Create(fileName);
        byte[] info = encoding.GetBytes(data);
        outFile.Write(info, 0, info.Length);
        outFile.Close();
    }
}
