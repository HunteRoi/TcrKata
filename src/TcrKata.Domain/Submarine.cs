namespace TcrKata.Domain;

public class Submarine : ISubmarine, IDisposable
{
    private record Command(string Name, int Value);
    private record State(int Aim, int Position, int Depth);

    private State _state = new(0, 0, 0);
    private ICommandParser? _commandParser;

    public Submarine()
    {
        this._commandParser = new CommandParser();
    }

    public void ExecuteCommand(string command)
    {
        var commandObject = this.CreateCommand(command.Split(' '));

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

    private Command CreateCommand(string[] commandTokens) => new(commandTokens[0], int.Parse(commandTokens[1]));

    public void Dispose()
    {
        this._commandParser = null;
    }
}