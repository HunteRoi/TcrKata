namespace TcrKata.Domain;

/// <summary>
/// Stand still, boy
/// </summary>
/// <seealso cref="TcrKata.Domain.ICommand"/>
public class NoMoveCommand : ICommand
{
    public string Name => "stand_still";
    public int Value => 0;

    public State Execute(State currentState)
    {
        throw new NotImplementedException();
    }
}