namespace TcrKata.Domain;

public class UpCommand : ICommand
{
    public string Name => "up";
    public int Value { get; init; }
}