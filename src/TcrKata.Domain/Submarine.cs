using LanguageExt;

namespace TcrKata.Domain;

/// <summary>
///     pioup pioup
/// </summary>
/// <seealso cref="TcrKata.Domain.ISubmarine" />
/// <seealso cref="System.IDisposable" />
public class Submarine : ISubmarine, IDisposable
{
    /// <summary>
    ///     The command parser
    /// </summary>
    private readonly ICommandParser _commandParser;

    /// <summary>
    ///     The state
    /// </summary>
    private State _state;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Submarine" /> class.
    /// </summary>
    public Submarine()
    {
        this._state = new State(0, 0, 0);
        this._commandParser = new CommandParser();
    }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting
    ///     unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Executes the command.
    /// </summary>
    /// <param name="command">The command.</param>
    public void ExecuteCommand(string command) =>
        this._state = this._commandParser
            .CreateCommand(command)
            .Bind(this.GetNextState)
            .Match(_ => _, this._state);

    /// <summary>
    ///     Gets the aim.
    /// </summary>
    /// <value>The aim.</value>
    public int Aim => this._state.Aim;

    /// <summary>
    ///     Gets the position.
    /// </summary>
    /// <value>The position.</value>
    public int Position => this._state.Position;

    /// <summary>
    ///     Gets the depth.
    /// </summary>
    /// <value>The depth.</value>
    public int Depth => this._state.Depth;

    private Option<State> GetNextState(ICommand command) => command.Execute(this._state);
}