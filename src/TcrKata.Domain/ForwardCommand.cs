namespace TcrKata.Domain;

public class ForwardCommand : ICommand
{
    public string Name => "forward";
    public int Value { get; init; }

    public State Execute(State currentState)
    {
        return currentState with { Aim = currentState.Aim - this.Value };
    }
}