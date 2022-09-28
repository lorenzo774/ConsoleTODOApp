using ConsoleTODOApp.Errors;

namespace ConsoleTODOApp.Systems.Commands;

public interface IGetListCommand : ICommand { }

public class GetListCommand : IGetListCommand
{
    private readonly IIOLists _ioLists;
    private readonly IListExplorer _listExplorer;

    public GetListCommand(IIOLists ioLists, IListExplorer listExplorer)
    {
        _ioLists = ioLists;
        _listExplorer = listExplorer;
    }
    
    public void Execute(List<string> arguments)
    {
        if (arguments.Count <= 0)
        {
            throw new CommandException() { Msg = "No list name specified" };
        }
        var todoList = _ioLists.Load(arguments[0]);
        if (todoList == null)
        {
            throw new CommandException() { Msg = "List not found" };
        }
        
        _listExplorer.Explore(todoList);
    }
}