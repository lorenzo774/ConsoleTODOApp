namespace ConsoleTODOApp.Library;

public class TODO
{
    public bool Checked { get; set; } = false;
    public string Message { get; set; } = "";

    public override string ToString() => $"- [{(Checked ? "\u221A" : " ")}] {Message}";
}