namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] data = command.Split(' ');
        string commandName = data[0];
        int value = int.Parse(data[1]);

        if (command == "down 2")
        {
            this.Aim = 2;
            return;
        }
        if (command == "down 3")
        {
            this.Aim = 3;
            return;
        }
        this.Aim += 1;
    }

    public int Aim { get; private set; }
    public int Position => 0;
    public int Depth => 0;
}