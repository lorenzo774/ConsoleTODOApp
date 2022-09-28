namespace ConsoleTODOApp.Systems.Commands;

public interface ICommand
{
    void Execute(List<string> arguments);
}