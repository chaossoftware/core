using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace ChaosSoft.Core.IO
{
    /// <summary>
    /// Provides with methods for reading of data files with timeseries.
    /// </summary>
    public static class DataReader
    {
        /// <summary>
        /// Reads file from specific path and gets specified data range from the file using column delimiter regex.
        /// </summary>
        /// <param name="file">path to file to read</param>
        /// <param name="startOffset">amount of lines to skip for reading</param>
        /// <param name="readLines">amount of lines to read</param>
        /// <param name="delimiterRegex">regex fo column delimeter</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static double[][] ReadColumnsFromFile(string file, int startOffset, int readLines, string delimiterRegex)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException("Source data file not found.", file);
            }

            int i, j;

            string[] sourceData = File.ReadAllLines(file);

            // Determine how many numbers in line.
            int columns = Regex.Split(sourceData[startOffset].Trim(), delimiterRegex).Length;

            int length = readLines == 0 ? sourceData.Length - startOffset : readLines;

            double[][] dataColumns = new double[columns][];

            for (i = 0; i < dataColumns.Length; i++)
            {
                dataColumns[i] = new double[length];
            }

            for (i = startOffset; i < length + startOffset; i++)
            {
                var numbers = Regex.Split(sourceData[i].Trim(), delimiterRegex);

                for (j = 0; j < columns; j++)
                {
                    if (double.TryParse(numbers[j], NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        dataColumns[j][i - startOffset] = value;
                    }
                    else
                    {
                        throw new ArgumentException(
                            $"Unable to parse value (Line: {i + 1}, Column: {j + 1} [value: {numbers[j]}])");
                    }
                }
            }

            return dataColumns;
        }

        /// <summary>
        /// Reads file from specific path and gets specified data range from the file considering column delimeter as whitespace.
        /// </summary>
        /// <param name="file">path to file to read</param>
        /// <param name="startOffset">amount of lines to skip for reading</param>
        /// <param name="readLines">amount of lines to read</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static double[][] ReadColumnsFromFile(string file, int startOffset, int readLines) =>
            ReadColumnsFromFile(file, startOffset, readLines, "\\s+");

        /// <summary>
        /// Reads source data file as serialized double[][].
        /// </summary>
        /// <param name="fileName">path to file to read</param>
        /// <returns></returns>
        public static double[][] ReadColumnsFromByteFile(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Seek(0, 0);
                return (double[][])(new BinaryFormatter().Deserialize(ms));
            }
        }
    }
}
