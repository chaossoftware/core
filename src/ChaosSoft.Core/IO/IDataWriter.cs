namespace ChaosSoft.Core.IO;

/// <summary>
/// Interface for components which should read data from source.
/// </summary>
public interface IDataWriter<T>
{
    /// <summary>
    /// Writes retrievedd data to specified destination.
    /// </summary>
    /// <param name="destination">destination to write the data</param>
    /// <param name="data">data to write</param>
    void WriteData(string destination, T data);
}
