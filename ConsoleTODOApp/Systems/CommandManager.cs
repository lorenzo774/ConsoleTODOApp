using ConsoleTODOApp.Systems.Commands;

namespace ConsoleTODOApp.Systems;

public class CommandManager : ICommandManager
{
    public void RunCommand(ICommand command, List<string> arguments)
    {
        command.Execute(arguments);
    }
}