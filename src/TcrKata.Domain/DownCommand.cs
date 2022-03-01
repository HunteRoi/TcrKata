namespace TcrKata.Domain;

public class DownCommand : ICommand
{
    public int Value { get; init; }

    public State Execute(State currentState)
    {
        return currentState with { Aim = currentState.Aim + this.Value };
    }
}