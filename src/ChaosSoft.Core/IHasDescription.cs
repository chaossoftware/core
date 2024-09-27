namespace ChaosSoft.Core;

/// <summary>
/// Interface for components which should have description.
/// </summary>
public interface IHasDescription
{
    /// <summary>
    /// Gets item description.
    /// </summary>
    string Description { get; }
}
