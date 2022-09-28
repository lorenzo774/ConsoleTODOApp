using ConsoleTODOApp.Systems.Commands;

namespace ConsoleTODOApp.Input;

public interface ICommandExtractor
{
    ICommand ExtractFromCLI();
}