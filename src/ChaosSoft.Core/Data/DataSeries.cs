using ChaosSoft.Core.DataUtils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChaosSoft.Core.Data;

/// <summary>
/// Represents data series (series of <see cref="DataPoint"/>).<br/>
/// Properties calculation is optimized (re-calculated only if data changed).
/// </summary>
public sealed class DataSeries : IHasName
{
    private int length;
    private DataPoint max;
    private DataPoint min;
    private DataPoint amplitude;
    private double[] xValues;
    private double[] yValues;
    private bool outdated;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSeries"/> class with empty data.
    /// </summary>
    public DataSeries()
    {
        DataPoints = new List<DataPoint>();
        length = 0;
        min = new DataPoint(0, 0);
        max = new DataPoint(0, 0);
        amplitude = new DataPoint(0, 0);
        outdated = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSeries"/> class for specific one-dimension timeseries.<br/>
    /// In this case timestep is equal to 1. 
    /// </summary>
    /// <param name="timeSeries">source timeseries</param>
    public DataSeries(double[] timeSeries) : this()
    {
        foreach (double val in timeSeries)
        {
            AddDataPoint(val);
        }
    }

    /// <summary>
    /// Gets data series name (if any).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets list of data points.
    /// </summary>
    public List<DataPoint> DataPoints { get; }

    /// <summary>
    /// Gets Max Y value of data series (re-calculated only of series changed).
    /// </summary>
    public DataPoint Max
    {
        get
        {
            if (outdated)
            {
                UpdateProperties();
            }

            return max;
        }
    }

    /// <summary>
    /// Gets Min Y value of data series (re-calculated only of series changed).
    /// </summary>
    public DataPoint Min
    {
        get
        {
            if (outdated)
            {
                UpdateProperties();
            }

            return min;
        }
    }

    /// <summary>
    /// Gets amplitude of Y values of data series (re-calculated only of series changed).
    /// </summary>
    public DataPoint Amplitude
    {
        get
        {
            if (outdated)
            {
                UpdateProperties();
            }

            return amplitude;
        }
    }

    /// <summary>
    /// Gets length of data series (re-calculated only of series changed).
    /// </summary>
    public int Length
    {
        get
        {
            if (outdated)
            {
                UpdateProperties();
            }

            return length;
        }
    }

    /// <summary>
    /// Gets array of X values (re-calculated only of series changed).
    /// </summary>
    public double[] XValues
    {
        get
        {
            if (outdated)
            {
                xValues = (from dp in DataPoints select dp.X).ToArray();
            }

            return xValues;
        }
    }

    /// <summary>
    /// Gets array of Y values (re-calculated only of series changed).
    /// </summary>
    public double[] YValues
    {
        get
        {
            if (outdated)
            {
                yValues = (from dp in DataPoints select dp.Y).ToArray();
            }

            return yValues;
        }
    }

    /// <summary>
    /// Adds new <see cref="DataPoint"/> based on two coordinates.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public void AddDataPoint(double x, double y)
    {
        DataPoints.Add(new DataPoint(x, y));
        outdated = true;
    }

    /// <summary>
    /// Adds new <see cref="DataPoint"/> based on Y coordinate.
    /// (x coordinate is calculated as current length of series)
    /// </summary>
    /// <param name="y">Y coordinate</param>
    public void AddDataPoint(double y)
    {
        DataPoints.Add(new DataPoint(DataPoints.Count, y));
        outdated = true;
    }

    /// <summary>
    /// Gets string representation of the series with specified number format.
    /// </summary>
    /// <param name="format">number format to use</param>
    /// <param name="columnDelimiter">columns delimiter</param>
    /// <returns></returns>
    public string ToString(string format, string columnDelimiter)
    {
        StringBuilder sb = new();

        foreach (DataPoint dp in DataPoints)
        {
            sb.Append(NumFormat.Format(dp.X, format))
                .Append(columnDelimiter)
                .AppendLine(NumFormat.Format(dp.Y, format));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Gets string representation of the series with specified number format and TAB delimiter.
    /// </summary>
    /// <param name="format">number format to use</param>
    /// <returns></returns>
    public string ToString(string format) => 
        ToString(format, "\t");

    /// <summary>
    /// Gets string representation of the series with 
    /// <see cref="NumFormat.CurrentFormat"/> number format and TAB delimiter.
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
        ToString(NumFormat.CurrentFormat, "\t");

    private void UpdateProperties()
    {
        length = DataPoints.Count;
        min = new DataPoint(Vector.Min(XValues), Vector.Min(YValues));
        max = new DataPoint(Vector.Max(XValues), Vector.Max(YValues));
        amplitude = new DataPoint(max.X - min.X, max.Y - min.Y);
        outdated = false;
    }
}
