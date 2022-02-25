namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] data = command.Split(' ');
        string commandName = data[0];
        int value = int.Parse(data[1]);

        if (commandName == "down")
        {
            this.Aim = value;
            return;
        }
        if (commandName == "up")
        {
            this.Aim = 0 - value;
            return;
        }
    }

    public int Aim { get; private set; }
    public int Position => 0;
    public int Depth => 0;
}