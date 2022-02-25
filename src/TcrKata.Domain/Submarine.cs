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
                return;
            case "up":
                this.Aim -= value;
                return;
            case "forward":
                this.Position += value;
                return;
        }
    }

    public int Aim { get; private set; }
    public int Position { get; private set; }
    public int Depth => 0;
}