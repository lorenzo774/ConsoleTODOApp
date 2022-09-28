namespace ConsoleTODOApp.Library;

public class TODOList
{
    public string Name { get; set; } = "list";
    public List<TODO> TODOs { get; init; } = new();

    public bool CanEdit(int index)
    {
        return !(TODOs.Count == 0 || index >= TODOs.Count || index < 0);
    }
    
    public void AddTODO(int index, bool up = true)
    {
        if (TODOs.Count == 0)
        {
            TODOs.Add(new TODO());
            return;
        }
        if (!up)
        {
            TODOs.Insert(index + 1, new TODO());
            return;
        }
        TODOs.Insert(index, new TODO());
    }

    public void RemoveTODO(int index)
    {
        if (!CanEdit(index))
        {
            return;
        }
        TODOs.RemoveAt(index);
    }

    public void EditMessage(int index, string? newMsg)
    {
        if (!CanEdit(index))
        {
            return;
        }
        if (!string.IsNullOrEmpty(newMsg))
        {
            TODOs[index].Message = newMsg;
        }
    }
    
    public void ToggleTODO(int index)
    {
        if (TODOs.Count == 0 || index >= TODOs.Count || index < 0)
        {
            return;
        }
        TODOs[index].Checked = !TODOs[index].Checked;
    }
    
    public override string ToString() => $"Name: {Name}\n\n{string.Join("\n", TODOs)}";
}