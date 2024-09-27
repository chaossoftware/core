using System;
using System.IO;
using ChaosSoft.Core.IO;

namespace ChaosSoft.Core.Data;

/// <summary>
/// Represents source file data with any number of data colmns. 
/// </summary>
public sealed class SourceData
{
    private readonly double[][] _dataColumns;

    /// <summary>
    /// Initializes a new instance of the <see cref="SourceData"/> class based on specified data reader instance and 
    /// source.
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="filePath"></param>
    public SourceData(IDataReader dataReader, string filePath)
    {
        _dataColumns = dataReader.ReadColumnsFromFile(filePath);

        if (!string.IsNullOrEmpty(filePath))
        {
            FileName = Path.GetFileName(filePath);
            Folder = Path.GetDirectoryName(filePath);
        }
        
        LinesCount = _dataColumns[0].Length;
        ColumnsCount = _dataColumns.Length;

        SetTimeSeries(0, 0, LinesCount, 1, false);
    }

    /// <summary>
    /// Gets count of lines in source data.
    /// </summary>
    public int LinesCount { get; }

    /// <summary>
    /// Gets count of columns in source data.
    /// </summary>
    public int ColumnsCount { get; }

    /// <summary>
    /// Gets source file name.
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Gets source folder.
    /// </summary>
    public string Folder { get; }

    /// <summary>
    /// Gets current data series.
    /// </summary>
    public DataSeries TimeSeries { get; private set; }

    /// <summary>
    /// Gets current data step size.
    /// </summary>
    public double Step { get; private set; }

    /// <summary>
    /// Gets source data from double[][] serializaed to a file.
    /// </summary>
    /// <param name="filePath">path to file with serializaed data</param>
    /// <returns></returns>
    public static SourceData FromBytesFile(string filePath) =>
        new(new BinaryDataFileReader(), filePath);

    /// <summary>
    /// Gets source data from plain text file using default <see cref="PlainTextFileReader()"/> reader constructor.
    /// </summary>
    /// <param name="filePath">path to file with text data</param>
    /// <returns></returns>
    public static SourceData FromPlainTextFile(string filePath) =>
        new(new PlainTextFileReader(), filePath);

    /// <summary>
    /// Set current time series from column and data range.
    /// </summary>
    /// <param name="colIndex">index of column</param>
    /// <param name="startPoint">start point for time series</param>
    /// <param name="endPoint">end point for time series</param>
    /// <param name="pts">use each N point from range</param>
    /// <param name="timeInFirstColumn">specify whether to use first column values as time or not</param>
    public void SetTimeSeries(int colIndex, int startPoint, int endPoint, int pts, bool timeInFirstColumn)
    {
        int max = (endPoint - startPoint) / pts;
        TimeSeries = new DataSeries();

        for (int i = 0; i < max; i++)
        {
            int row = startPoint + i * pts;
            var x = timeInFirstColumn ? _dataColumns[0][row] : i + 1;
            var y = _dataColumns[colIndex][row];
            TimeSeries.AddDataPoint(x, y);
        }

        try
        {
            Step = timeInFirstColumn ? _dataColumns[0][pts] - _dataColumns[0][0] : double.NaN;
        }
        catch (IndexOutOfRangeException)
        {
            Step = double.NaN;
        }
    }

    /// <summary>
    /// Gets data column with specific index.
    /// </summary>
    /// <param name="index">column index in data file</param>
    /// <returns></returns>
    public double[] GetColumn(int index) =>
        _dataColumns[index];

    /// <summary>
    /// Gets main information on source data file.
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
        $"File: {FileName} (lines: {LinesCount}, columns: {ColumnsCount})";
}
