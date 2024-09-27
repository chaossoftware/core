namespace ChaosSoft.Core;

/// <summary>
/// Interface for components which should have name.
/// </summary>
public interface IHasName
{
    /// <summary>
    /// Gets readable humanized item name.
    /// </summary>
    string Name { get; }
}
