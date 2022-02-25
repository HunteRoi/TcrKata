namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] data = command.Split(' ');
        string commandName = data[0];
        int value = int.Parse(data[1]);

        if (commandName == "down" && value == 2)
        {
            this.Aim = value;
            return;
        }
        if (commandName == "down" && value == 3)
        {
            this.Aim = value;
            return;
        }
        this.Aim += 1;
    }

    public int Aim { get; private set; }
    public int Position => 0;
    public int Depth => 0;
}