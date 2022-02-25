namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        this.Aim += 1;
    }

    public int Aim { get; private set; }
    public int Position => 0;
    public int Depth => 0;
}