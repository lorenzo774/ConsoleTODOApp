using ConsoleTODOApp.Errors;
using ConsoleTODOApp.Input;
using ConsoleTODOApp.Systems;

namespace ConsoleTODOApp;

public class Application : IApplication
{
    private readonly IInputReader _inputReader;
    private readonly ICommandManager _commandManager;
    private readonly IMessage _message;

    public Application(
        IMessage message, 
        IInputReader inputReader, 
        ICommandManager commandManager)
    {
        _message = message;
        _inputReader = inputReader;
        _commandManager = commandManager;
    }

    public void Run()
    {
        var input = _inputReader.Read();
        try
        {
            _commandManager.RunCommand(input.Command, input.Arguments);
        }
        catch (CommandException e)
        {
            _message.Error(e.Msg);
        }
    }
}