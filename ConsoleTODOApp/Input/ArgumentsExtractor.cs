namespace ConsoleTODOApp.Input;

public class ArgumentsExtractor : IArgumentsExtractor
{
    private const int ARGUMENTS_INDEX = 2;
    
    public List<string> Extract()
    {
        var args = Environment.GetCommandLineArgs().ToList();
        if (args.Count <= ARGUMENTS_INDEX)
        {
            return new();
        }
        
        return args.GetRange(ARGUMENTS_INDEX, args.Count - ARGUMENTS_INDEX);
    }
}