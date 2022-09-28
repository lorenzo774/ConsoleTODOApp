namespace ConsoleTODOApp.Errors;

public class CommandException : Exception
{
    public string Msg { get; init; } = "Error";
}