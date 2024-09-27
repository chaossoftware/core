# ChaosSoft.Core

Core of the ChaosSoft toolset.

Contains:
* Custom data series implementation
* Data I/O
* Helpers for Matrixes and Vectors
* Logger instance (_+ default ConsoleLogger implementation_)

## Code examples

### Read source data from file
```csharp
using ChaosSoft.Core.Data;
using ChaosSoft.Core.IO;

string fileName = "some_data.dat";
int linesToSkip = 2;
int linesToRead = 500;

// get source data from file
IDataReader dataReader = new PlainTextFileReader(linesToSkip, linesToRead);
SourceData data = new SourceData(dataReader, linesToRead);

// assume file has two columns (1st - timestamp, 2nd - series)
int seriesColumn = 1;
bool timeInFirstColumn = true;
int startPoint = 0;
int eachNpoints = 2;

// set current timeseries taking every second point of the data considering timestamp from first column of data file.
data.SetTimeSeries(
    seriesColumn,
    startPoint,
    data.LinesCount - 1,
    eachNpoints,
    timeInFirstColumn);

// get amplitude of timeseries
var amplitude = data.TimeSeries.Amplitude.Y;  //X property contains amplitude of X values (timestamp)
```

### Work with matrixes
```csharp
using ChaosSoft.Core.DataUtils;

// create 3x5 2D array filled with value 5.3
var matrix = Matrix.Create(3, 5, 5.3);

// get second column of the matrix
var column = Matrix.GetColumn(matrix, 2);
```

### Work with vectors
```csharp
using ChaosSoft.Core.DataUtils;

// create vector of length 5, starting from -9 with step 3
var vector = Vector.CreateUniform(5, -9, 3);

// find vector's Max absolute value
var maxAbs = Vector.MaxAbs(vector);
```

### Numbers formatting
By default numbers formatting is set to `"0.#######"` with `InvariantCulture`

```csharp
// To apply user formatting used by default (for example F2)
NumFormat.CurrentFormat = "F2";

// To apply culture used by default (for example en-US)
NumFormat.CurrentCulture = new CultureInfo("en-US");

// To reset formatting defaults
NumFormat.Reset();

// To set default precision (for example 11 decimal digits)
NumFormat.SetPrecision(11);
```