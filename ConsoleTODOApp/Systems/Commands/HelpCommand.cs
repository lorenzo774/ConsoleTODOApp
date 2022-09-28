namespace ConsoleTODOApp.Systems.Commands;

public interface IHelpCommand : ICommand { }

public class HelpCommand : IHelpCommand
{
    private readonly IMessage _message;

    public HelpCommand(IMessage message)
    {
        _message = message;
    }
    
    public void Execute(List<string> arguments)
    {
        _message.Help();
    }
}