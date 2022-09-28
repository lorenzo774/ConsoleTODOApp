using ConsoleTODOApp.Library;

namespace ConsoleTODOApp.Systems.Commands;

public interface INewListCommand : ICommand { }

public class NewListCommand : INewListCommand
{
    private readonly IIOLists _ioLists;

    public NewListCommand(IIOLists ioLists)
    {
        _ioLists = ioLists;
    }
    
    public void Execute(List<string> arguments)
    {
        var todoList = new TODOList();
        if (arguments.Count > 0)
        {
            todoList.Name = arguments[0];
        }
        _ioLists.Save(todoList);
    }
}