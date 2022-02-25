namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] data = command.Split(' ');
        var commandObject = this.CreateCommand(data);
        
        switch (commandObject.Name)
        {
            case "down":
                this.Aim += commandObject.Value;
                break;
            case "up":
                this.Aim -= commandObject.Value;
                break;
            case "forward":
                this.Position += commandObject.Value;
                this.Depth += this.Aim * commandObject.Value;
                break;
            default:
                break;
        }
    }

    public int Aim { get; private set; }
    public int Position { get; private set; }
    public int Depth { get; private set; }

    private record Command(string Name, int Value);

    private Command CreateCommand(string[] commandTokens) => new(commandTokens[0], int.Parse(commandTokens[1]));
}