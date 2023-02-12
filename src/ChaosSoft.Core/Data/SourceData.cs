﻿using System.IO;
using System.Text;
using ChaosSoft.Core.IO;

namespace ChaosSoft.Core.Data
{
    public sealed class SourceData
    {
        private readonly double[][] _dataColumns;

        public SourceData(string filePath, int startOffset, int readLines) :
            this(DataReader.ReadColumnsFromFile(filePath, startOffset, readLines), filePath)
        {
        }

        public SourceData(string filePath) : 
            this(DataReader.ReadColumnsFromFile(filePath, 0, 0), filePath)
        {
        }

        public SourceData(double[][] data, string filePath)
        {
            _dataColumns = data;

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
        public static SourceData FromBytesFile(string filePath)
        {
            double[][] data = DataReader.ReadColumnsFromByteFile(filePath);
            return new SourceData(data, filePath);
        }

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
                    
            Step = TimeSeries.DataPoints[1].X - TimeSeries.DataPoints[0].X;
        }

        public double[] GetColumn(int index) =>
            _dataColumns[index];

        public string GetTimeSeriesAsString()
        {
            StringBuilder timeSeriesOut = new StringBuilder();

            foreach (double value in TimeSeries.YValues)
            {
                timeSeriesOut.AppendLine(NumFormatter.ToLong(value));
            }

            return timeSeriesOut.ToString();
        }

        public override string ToString() =>
            $"File: {FileName}\nLines: {LinesCount}\nColumns: {ColumnsCount}";
    }
}
