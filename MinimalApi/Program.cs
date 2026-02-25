using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MinimalApi.Services;

var builder = WebApplication.CreateBuilder();
var services = builder.Services;
var configuration = builder.Configuration;
services.AddControllers();
services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseRouting();





// ===== first task =====


app.MapGet("/", () => "Hello Senioroo");

app.MapGet("/sum/{a}/{b}", (int a, int b) =>
{
    return Results.Ok(a + b);
});




// ===== second task =====


// var nextId = 3;
//
// var todos = new List<TodoItem>
// {
//     new TodoItem(1, "Task", true),
//     new TodoItem(2, "GO!", false)
// };
//
// var todoGroup = app.MapGroup("/api/todo");
//
// todoGroup.MapGet("/", () => Results.Ok(todos));
//
// todoGroup.MapPost("/", (TodoItem _todoItem) =>
// {
//     var newItem = _todoItem with { Id = nextId++ };
//     todos.Add(newItem);
//     return Results.Created($"/api/todo/{newItem}", newItem);
// });
//
// todoGroup.MapDelete("/{id}", (int id) =>
// {
//     var item = todos.FirstOrDefault(t => t.Id == id);
//     if (item == null) return Results.NotFound();
//
//     todos.Remove(item);
//     return Results.NoContent();
// });




// ===== taske 3 =====


app.MapGet("/api/todo/{id}", (int id) => TodoService.GetById(id));
app.MapPost("api/todo/", (TodoItem _todoItem) => TodoService.Create(_todoItem));


app.Run();


public record TodoItem(int Id, string Title, bool IsCompleted);

