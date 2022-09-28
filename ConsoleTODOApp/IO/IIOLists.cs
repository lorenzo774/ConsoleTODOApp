using ConsoleTODOApp.Library;

namespace ConsoleTODOApp.Systems;

public interface IIOLists
{
    TODOList Load(string name);
    void Save(TODOList todoList);
    void Remove(string name);
}