namespace TcrKata.Domain;

public class DownCommand : ICommand
{
    public int Value { get; init; }
}