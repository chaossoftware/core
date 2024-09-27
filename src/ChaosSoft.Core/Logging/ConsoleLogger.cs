using System;

namespace ChaosSoft.Core.Logging;

/// <summary>
/// Logging to console. 
/// </summary>
public class ConsoleLogger : ILogger
{
    /// <summary>
    /// Logs message with error level
    /// </summary>
    /// <param name="message">message to log</param>
    /// <param name="parameters">parameters to substitute to message template</param>
    public void Error(string message, params object[] parameters) =>
        Console.WriteLine("Error :: " + message, parameters);

    /// <summary>
    /// Logs message with warning level
    /// </summary>
    /// <param name="message">message to log</param>
    /// <param name="parameters">parameters to substitute to message template</param>
    public void Warn(string message, params object[] parameters) =>
        Console.WriteLine("Warn  :: " + message, parameters);

    /// <summary>
    /// Logs message with informational level.
    /// </summary>
    /// <param name="message">message to log</param>
    /// <param name="parameters">parameters to substitute to message template</param>
    public void Info(string message, params object[] parameters) =>
        Console.WriteLine(message, parameters);

    /// <summary>
    /// Logs message with debug level
    /// </summary>
    /// <param name="message">message to log</param>
    /// <param name="parameters">parameters to substitute to message template</param>
    public void Debug(string message, params object[] parameters) =>
        Console.WriteLine("Debug :: " + message, parameters);

    /// <summary>
    /// Logs message with trace level
    /// </summary>
    /// <param name="message">message to log</param>
    /// <param name="parameters">parameters to substitute to message template</param>
    public void Trace(string message, params object[] parameters) =>
        Console.WriteLine("Trace :: " + message, parameters);


}
