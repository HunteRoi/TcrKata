﻿namespace TcrKata.Domain;

public interface ICommand
{
    string Name { get; }
    int Value { get; }
}