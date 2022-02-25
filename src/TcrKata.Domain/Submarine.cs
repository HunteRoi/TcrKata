namespace TcrKata.Domain;

public class Submarine : ISubmarine, IDisposable
{
    private record Command(string Name, int Value);
    private record State(int Aim, int Position, int Depth);

    private State _state;
    private ICommandParser? _commandParser;

    public Submarine()
    {
        this._state = new(0, 0, 0);
        this._commandParser = new CommandParser();
    }

    public void ExecuteCommand(string command)
    {
        var commandObject = this._commandParser!.CreateCommand(command.Split(' '));

        switch (commandObject.Name)
        {
            case "down":
                this._state = this._state with { Aim = this._state.Aim + commandObject.Value };
                break;

            case "up":
                this._state = this._state with { Aim = this._state.Aim - commandObject.Value };
                break;

            case "forward":
                this._state = this._state with
                {
                    Position = this._state.Position + commandObject.Value,
                    Depth = this._state.Depth + (this._state.Aim * commandObject.Value)
                };
                break;

            default:
                break;
        }
    }

    public int Aim => this._state.Aim;

    public int Position => this._state.Position;

    public int Depth => this._state.Depth;

    public void Dispose()
    {
        this._commandParser = null;
    }
}