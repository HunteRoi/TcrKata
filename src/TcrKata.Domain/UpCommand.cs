﻿namespace TcrKata.Domain;

public class UpCommand : ICommand
{
    public string Name => "up";
    public int Value { get; init; }

    public State Execute(State currentState)
    {
        return currentState with { Aim = currentState.Aim - this.Value };
    }
}