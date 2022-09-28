using ConsoleTODOApp.Errors;

namespace ConsoleTODOApp.Systems.Commands;

public interface IRemoveListCommand : ICommand { }

public class RemoveListCommand : IRemoveListCommand
{
    private readonly IIOLists _ioLists;

    public RemoveListCommand(IIOLists ioLists)
    {
        _ioLists = ioLists;
    }
    
    public void Execute(List<string> arguments)
    {
        if (arguments.Count <= 0)
        {
            throw new CommandException() { Msg = "No list name specified" };
        }
        _ioLists.Remove(arguments[0]);
        Console.WriteLine("\nList successfully removed");
    }
}