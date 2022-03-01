﻿using LanguageExt;

namespace TcrKata.Domain;

/// <summary>
/// A command parser for an instance of <see cref="Submarine" />
/// </summary>
public interface ICommandParser
{
    /// <summary>
    /// Creates the command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    Option<Func<State, State>> CreateCommand(string command);
}