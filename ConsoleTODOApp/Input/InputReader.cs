namespace ConsoleTODOApp.Input;

public class InputReader : IInputReader
{
    private readonly ICommandExtractor _commandExtractor;
    private readonly IArgumentsExtractor _argumentsExtractor;

    public InputReader(ICommandExtractor commandExtractor, IArgumentsExtractor argumentsExtractor)
    {
        _commandExtractor = commandExtractor;
        _argumentsExtractor = argumentsExtractor;
    }
    
    public InputResult Read()
    {
        var arguments = _argumentsExtractor.Extract();
        var command = _commandExtractor.ExtractFromCLI();
        var result = new InputResult()
        {
            Command = command, 
            Arguments = arguments
        };
        return result;
    }
}