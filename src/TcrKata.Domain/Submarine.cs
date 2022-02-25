namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    private record Command(string Name, int Value);
    private record State(int Aim, int Position, int Depth);

    private State _state = new(0, 0, 0);

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
                this._state = this._state with { Position = this._state.Position + commandObject.Value };
                this.Depth += this.Aim * commandObject.Value;
                break;

            default:
                break;
        }
    }

    public int Aim => this._state.Aim;

    public int Position => this._state.Position;

    public int Depth
    {
        get => this._state.Depth;
        private set
        {
            this._state = this._state with { Depth = value };
        }
    }

    private Command CreateCommand(string[] commandTokens) => new(commandTokens[0], int.Parse(commandTokens[1]));
}