namespace ChaosSoft.Core.Data;

/// <summary>
/// Represents 2D point object. 
/// </summary>
public readonly struct DataPoint
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataPoint"/> class for specific X and Y coordinates.
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    public DataPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Gets X coordinate.
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Gets Y coordinate.
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// Gets string representation of the data point (<see cref="NumFormat.CurrentFormat"/> format is used).
    /// </summary>
    /// <returns>string representation</returns>
    public override string ToString() =>
        $"[{X.ToString(NumFormat.CurrentFormat)}, {Y.ToString(NumFormat.CurrentFormat)}]";

    /// <summary>
    /// Gets string representation of the data point with specified number format.
    /// </summary>
    /// <param name="format">number format to use</param>
    /// <returns>string representation</returns>
    public string ToString(string format) =>
        $"[{X.ToString(format)}, {Y.ToString(format)}]";
}
