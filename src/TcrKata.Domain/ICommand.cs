namespace TcrKata.Domain;

/// <summary>
/// A command executable in an instance of <see cref="Submarine"/>
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    string Name { get; }

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <value>The value.</value>
    int Value { get; }

    /// <summary>
    /// Executes the specified current state.
    /// </summary>
    /// <param name="currentState">State of the current.</param>
    /// <returns></returns>
    State Execute(State currentState);
}