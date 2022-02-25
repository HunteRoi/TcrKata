namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] data = command.Split(' ');
        string commandName = data[0];
        int value = int.Parse(data[1]);
        
        switch (commandName)
        {
            case "down":
                this.Aim += value;
                break;
            case "up":
                this.Aim -= value;
                break;
            case "forward":
                this.Position += value;
                this.Depth += this.Aim * value;
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