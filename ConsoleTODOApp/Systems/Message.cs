using ConsoleTODOApp.Library;

namespace ConsoleTODOApp.Systems;

public class Message : IMessage
{
    private const string EDITOR_GUIDE = "EDITOR GUIDE\n\n" +
                                       "'q' to save and exit\n" +
                                       "'SPACE' to toggle a task\n" +
                                       "'u' (UP) to add a task before the selected task\n" +
                                       "'d' (DOWN) to add a task after the selected task\n" +
                                       "'r' to remove a task\n" +
                                       "'e' to edit a task\n\n";
    
    public void Help()
    {
        Console.WriteLine("\nConsoleTODOApp\n\n" +
                          "todoapp list [name] -> Get a saved TODO list\n" +
                          "todoapp new [name?] -> Create a new TODO list\n" +
                          "todoapp rm [name] -> Remove TODO list\n" +
                          "todoapp help -> Get this message");
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n" + message);
        Console.ResetColor();
    }

    public void DisplayList(TODOList todoList, int highLightRow = -1)
    {
        Console.Clear();
        if (highLightRow == -1 || highLightRow >= todoList.TODOs.Count)
        {
            Console.WriteLine($"{EDITOR_GUIDE}{todoList}");
            return;
        }
        Console.WriteLine($"{EDITOR_GUIDE}Name: {todoList.Name}\n");
        for (int i = 0; i < highLightRow; i++)
        {
            Console.WriteLine(todoList.TODOs[i]);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(todoList.TODOs[highLightRow]);
        Console.ResetColor();
        for (int i = highLightRow + 1; i < todoList.TODOs.Count; i++)
        {
            Console.WriteLine(todoList.TODOs[i]);
        }
    }
}