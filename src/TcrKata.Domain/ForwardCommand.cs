namespace TcrKata.Domain;

public class ForwardCommand : ICommand
{
    public int Value { get; init; }
}