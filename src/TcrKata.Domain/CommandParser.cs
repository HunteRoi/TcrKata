using LanguageExt;
using static LanguageExt.Prelude;

namespace TcrKata.Domain;

public class CommandParser : ICommandParser
{
    public Option<Func<State, State>> CreateCommand(string command)
    {
        string[] commandTokens = command.Split(' ');
        int value = int.Parse(commandTokens[1]);

        State ExecuteUpCommand(State currentState) => currentState with { Aim = currentState.Aim - value };
        State ExecuteDownCommand(State currentState) => currentState with { Aim = currentState.Aim + value };
        State ExecuteForwardCommand(State currentState) => currentState with
        {
            Position = currentState.Position + value,
            Depth = currentState.Depth + (currentState.Aim * value)
        };

        return commandTokens[0].ToLower() switch
        {
            "up" => Some(ExecuteUpCommand),
            "down" => Some(ExecuteDownCommand),
            "forward" => Some(ExecuteForwardCommand),
            _ => Option<Func<State, State>>.None,
        };
    }
}