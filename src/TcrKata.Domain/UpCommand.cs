namespace TcrKata.Domain;

public class UpCommand : ICommand
{
    public int Value { get; init; }
}