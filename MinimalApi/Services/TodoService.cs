namespace MinimalApi.Services;

public static class TodoService
{
    private static List<TodoItem> Items = new();
    private static int NextId { get; set; } = 1;

    public static IResult GetById(int id)
    {
        var item = Items.FirstOrDefault(t => t.Id == id);
        if (item == null) return Results.NotFound();
        if (item.IsCompleted == false) return Results.NotFound();

        return Results.Ok(item);
    }

    public static IResult Create(TodoItem _todoItem)
    {
        var newItem = _todoItem with { Id = NextId++ };
        Items.Add(newItem);
        return Results.Created($"/api/todo/{newItem}", newItem);
    }
}