using ConsoleTODOApp.Errors;
using ConsoleTODOApp.Library;

namespace ConsoleTODOApp.Systems;

public class ListExplorer : IListExplorer
{
    private int _index = 0;
    private readonly IMessage _message;
    private readonly IIOLists _ioLists;
    
    public ListExplorer(IMessage message, IIOLists ioLists)
    {
        _message = message;
        _ioLists = ioLists;
    }
    
    public void Explore(TODOList todoList)
    {
        char keyPressed = 'a';
        while (keyPressed != 'q')
        {
            _message.DisplayList(todoList, _index);
            keyPressed = Console.ReadKey(true).KeyChar;
            switch (keyPressed)
            {
                case 'j':
                    _index += 1;
                    break;
                case 'k':
                    _index -= 1;
                    break;
                case 'u':
                    todoList.AddTODO(_index);
                    break;
                case 'd':
                    todoList.AddTODO(_index, false);
                    break;
                case 'r':
                    todoList.RemoveTODO(_index);
                    break;
                case 'e':
                    if (!todoList.CanEdit(_index)) continue;
                    Console.Write("\nMessage: ");
                    string? msg = Console.ReadLine();
                    todoList.EditMessage(_index, msg);
                    break;
                case ' ':
                    todoList.ToggleTODO(_index);
                    break;
            }
            if (_index >= todoList.TODOs.Count)
            {
                _index = 0;
            }
            if (_index < 0)
            {
                _index = todoList.TODOs.Count - 1;
            }
        }
        _ioLists.Save(todoList);
    }
}