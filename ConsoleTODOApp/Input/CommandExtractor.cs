using ConsoleTODOApp.Systems.Commands;

namespace ConsoleTODOApp.Input;

public class CommandExtractor : ICommandExtractor
{
    public IGetListCommand NewListCommand { get; private set; }
    
    private const int COMMAND_INDEX = 1;
    
    private readonly IHelpCommand _helpCommand;
    
    private readonly Dictionary<string, ICommand> _nameCommands;

    public CommandExtractor(
        IGetListCommand getListCommand, 
        IHelpCommand helpCommand, 
        INewListCommand newListCommand,
        IRemoveListCommand removeListCommand)
    {
        NewListCommand = getListCommand;
        _helpCommand = helpCommand;
        _nameCommands = new()
        {
            { "new", newListCommand },
            { "list", getListCommand },
            { "help", helpCommand },
            { "rm", removeListCommand }
        };
    }

    public ICommand ExtractFromCLI()
    {
        var args = Environment.GetCommandLineArgs().ToList();
        if (args.Count <= COMMAND_INDEX)
        {
            return _helpCommand;
        }

        string name = args[COMMAND_INDEX];
        
        return !_nameCommands.ContainsKey(name) ? _helpCommand : _nameCommands[name];
    }
}