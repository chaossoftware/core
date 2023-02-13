using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ChaosSoft.Core.IO
{
    /// <summary>
    /// Provides with methods for data writing.
    /// </summary>
    public class DataWriter
    {
        /// <summary>
        /// Created file with specific name and data.
        /// </summary>
        /// <param name="fileName">file name to create</param>
        /// <param name="data">string data to write</param>
        public static void CreateDataFile(string fileName, string data)
        {
            File.Delete(fileName);
            FileStream outFile = File.Create(fileName);
            byte[] info = new UTF8Encoding(true).GetBytes(data);
            outFile.Write(info, 0, info.Length);
            outFile.Close();
        }

        /// <summary>
        /// Writes multidimensional array data into specified file with specified number format.
        /// </summary>
        /// <param name="fileName">path to file to create</param>
        /// <param name="data">data to write</param>
        /// <param name="format">numbers format to use</param>
        public static void CreateDataFile(string fileName, double[,] data, string format)
        {
            var output = new StringBuilder();

            for (int i = 0; i < data.GetLength(1); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    output.Append($"{data[j, i].ToString(format, CultureInfo.InvariantCulture)}\t");
                }

                output.AppendLine();
            }

            CreateDataFile(fileName, output.ToString());
        }

        /// <summary>
        /// Writes multidimensional array data into specified file with G6 number format.
        /// </summary>
        /// <param name="fileName">path to file to create</param>
        /// <param name="data">data to write</param>
        public static void CreateDataFile(string fileName, double[,] data) =>
            CreateDataFile(fileName, data, Format.Default);

        /// <summary>
        /// Create source data file and serialize data into it.
        /// </summary>
        /// <param name="fileName">path to file to create</param>
        /// <param name="data">data to serialize</param>
        /// <returns></returns>
        public static void CreateBytesDataFile(string fileName, double[][] data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, data);
                byte[] bytes = ms.ToArray();

                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
        }
    }
}
