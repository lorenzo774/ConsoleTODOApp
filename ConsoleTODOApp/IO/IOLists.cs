using ConsoleTODOApp.Errors;
using ConsoleTODOApp.Library;

namespace ConsoleTODOApp.Systems;

public class IOLists : IIOLists
{
    private readonly string? _folderPath;

    public IOLists()
    {
        _folderPath = Environment.CurrentDirectory;
    }

    public TODOList? Load(string name)
    {
        string filePath = $"{_folderPath}/{name}.md";
        if (!File.Exists(filePath))
        {
            return null;
        }

        var todoList = new TODOList() { Name = name };

        using (StreamReader sr = File.OpenText(filePath))
        {
            string? s;
            while ((s = sr.ReadLine()) != null)
            {
                if (!s.StartsWith("- ["))
                {
                    continue;
                }

                bool isChecked = s.ToLower().StartsWith("- [x");
                string message = s.Substring(6);
                var todo = new TODO() { Checked = isChecked, Message = message};
                todoList.TODOs.Add(todo);
            }
        }

        return todoList;
    }

    public void Save(TODOList todoList)
    {
        string filePath = $"{_folderPath}/{todoList.Name}.md";
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            return;
        }
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var todo in todoList.TODOs)
            {
                string todoString = todo.ToString().Replace('\u221A', 'x');
                sw.WriteLine(todoString);
            }            
        }
    }

    public void Remove(string name)
    {
        string filePath = $"{_folderPath}/{name}.md";
        if (!File.Exists(filePath))
        {
            throw new CommandException() { Msg = "List not found" };
        }
        File.Delete(filePath);
    }
}