namespace TcrKata.Domain;

/// <summary>
/// Stand still, boy
/// </summary>
/// <seealso cref="TcrKata.Domain.ICommand"/>
public class NoMoveCommand : ICommand
{
    public int Value => 0;
}