namespace TcrKata.Domain;

public class ForwardCommand : ICommand
{
    public string Name => "forward";
    public int Value { get; init; }
}