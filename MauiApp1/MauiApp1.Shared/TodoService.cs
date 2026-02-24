namespace MauiApp1;
using System.Text.Json;
using MauiApp1.Shared.Pages;

public class TodoService
{
    string file = string.Empty;

    public TodoService()
    {
        file = Path.Combine(Environment.GetFolderPath
        (Environment.SpecialFolder.ApplicationData),"items.json");
    }

    public void SaveItems(IEnumerable<TodoItem> items)
    {
        File.WriteAllText(file, JsonSerializer.Serialize(items));
    }

    public IEnumerable<TodoItem> LoadItems()
    {
        if (File.Exists(file))
        {
            return JsonSerializer.Deserialize<IEnumerable<TodoItem>>(File.ReadAllText(file)) ?? new List<TodoItem>();
        }
        return new List<TodoItem>();
    }
}