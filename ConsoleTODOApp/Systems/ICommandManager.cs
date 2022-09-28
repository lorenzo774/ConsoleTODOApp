using ConsoleTODOApp.Systems.Commands;

namespace ConsoleTODOApp.Systems;

public interface ICommandManager
{
    void RunCommand(ICommand command, List<string> arguments);
}