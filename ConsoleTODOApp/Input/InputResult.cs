using ConsoleTODOApp.Systems.Commands;

namespace ConsoleTODOApp.Input;

public class InputResult
{
    public List<string> Arguments { get; init; } = new();
    public ICommand Command { get; init; }
}