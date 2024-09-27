namespace ChaosSoft.Core.IO;

/// <summary>
/// Interface for components which should read data from source.
/// </summary>
public interface IDataReader
{
    /// <summary>
    /// Reads data from source as double[][] which represents columns and rows of the source
    /// </summary>
    /// <param name="source">data source</param>
    /// <returns>double[][] of data columns and rows</returns>
    double[][] ReadColumnsFromFile(string source);
}
