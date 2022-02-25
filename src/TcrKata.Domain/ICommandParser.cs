namespace TcrKata.Domain;

public interface ICommandParser
{
    ICommand CreateCommand(string[] commandTokens);
}