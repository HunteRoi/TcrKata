using LanguageExt;

namespace TcrKata.Domain;

public class CommandParser : ICommandParser
{
    public Option<Func<State, State>> CreateCommand(string command)
    {
        string[] commandTokens = command.Split(' ');
        int value = int.Parse(commandTokens[1]);
        return commandTokens[0].ToLower() switch
        {
            "up" => Prelude.Some<Func<State, State>>(currentState => currentState with { Aim = currentState.Aim - value }),
            "down" => Prelude.Some<Func<State, State>>(currentState => currentState with { Aim = currentState.Aim + value }),
            "forward" => Prelude.Some<Func<State, State>>(currentState => currentState with
            {
                Position = currentState.Position + value,
                Depth = currentState.Depth + (currentState.Aim * value)
            }),
            _ => Option<Func<State, State>>.None,
        };
    }
}