namespace TcrKata.Domain;

/// <summary>
/// A submarine
/// </summary>
public interface ISubmarine
{
    /// <summary>
    /// Gets the aim.
    /// </summary>
    /// <value>The aim.</value>
    int Aim { get; }

    /// <summary>
    /// Gets the position.
    /// </summary>
    /// <value>The position.</value>
    int Position { get; }

    /// <summary>
    /// Gets the depth.
    /// </summary>
    /// <value>The depth.</value>
    int Depth { get; }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="command">The command.</param>
    void ExecuteCommand(string command);
}