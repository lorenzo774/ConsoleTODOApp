using ConsoleTODOApp.Library;

namespace ConsoleTODOApp.Systems;

public interface IMessage
{
    void Help();
    void Error(string message);
    void DisplayList(TODOList todoList, int highLightRow = -1);
}