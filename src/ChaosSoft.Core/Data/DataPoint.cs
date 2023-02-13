using ChaosSoft.Core.IO;

namespace ChaosSoft.Core.Data
{
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
        /// Gets string representation of the data point (G6 number format is used).
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            $"[{Format.General(X)}, {Format.General(Y)}]";
    }
}
