using LanguageExt;

namespace TcrKata.Domain;

/// <summary>
/// pioup pioup
/// </summary>
/// <seealso cref="TcrKata.Domain.ISubmarine"/>
/// <seealso cref="System.IDisposable"/>
public class Submarine : ISubmarine, IDisposable
{
    /// <summary>
    /// The state
    /// </summary>
    private State _state;

    /// <summary>
    /// The command parser
    /// </summary>
    private readonly ICommandParser _commandParser;

    /// <summary>
    /// Initializes a new instance of the <see cref="Submarine"/> class.
    /// </summary>
    public Submarine()
    {
        this._state = new(0, 0, 0);
        this._commandParser = new CommandParser();
    }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="command">The command.</param>
    public void ExecuteCommand(string command)
    {
        this._state = this._commandParser
            .CreateCommand(command)
            .Map(c => c.Execute(this._state))
            .Match(v => v, this._state);
    }

    /// <summary>
    /// Gets the aim.
    /// </summary>
    /// <value>The aim.</value>
    public int Aim => this._state.Aim;

    /// <summary>
    /// Gets the position.
    /// </summary>
    /// <value>The position.</value>
    public int Position => this._state.Position;

    /// <summary>
    /// Gets the depth.
    /// </summary>
    /// <value>The depth.</value>
    public int Depth => this._state.Depth;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting
    /// unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}