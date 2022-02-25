namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        if (command == "down 2")
        {
            this.Aim = 2;
            return;
        }
        this.Aim += 1;
    }

    public int Aim { get; private set; }
    public int Position => 0;
    public int Depth => 0;
}