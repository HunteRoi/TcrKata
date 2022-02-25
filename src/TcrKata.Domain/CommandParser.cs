namespace TcrKata.Domain;

public class CommandParser : ICommandParser
{
    public ICommand CreateCommand(string command)
    {
        string[] commandTokens = command.Split(' ');
        return commandTokens[0].ToLower() switch
        {
            "up" => new UpCommand { Value = int.Parse(commandTokens[1]) },
            "down" => new DownCommand { Value = int.Parse(commandTokens[1]) },
            "forward" => new ForwardCommand { Value = int.Parse(commandTokens[1]) },
            _ => new NoMoveCommand(),
        };
    }
}