namespace TcrKata.Domain;

public class DownCommand : ICommand
{
    public string Name => "down";
    public int Value { get; init; }
}