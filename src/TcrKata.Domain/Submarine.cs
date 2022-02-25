namespace TcrKata.Domain;

public class Submarine : ISubmarine, IDisposable
{
    private State _state;
    private ICommandParser _commandParser;

    public Submarine()
    {
        this._state = new(0, 0, 0);
        this._commandParser = new CommandParser();
    }

    public void ExecuteCommand(string command)
    {
        var commandObject = this._commandParser!.CreateCommand(command.Split(' '));
        this._state = commandObject.Execute(this._state);
    }

    public int Aim => this._state.Aim;

    public int Position => this._state.Position;

    public int Depth => this._state.Depth;

    public void Dispose()
    {
        GC.SuppressFinalize(this._commandParser);
    }
}