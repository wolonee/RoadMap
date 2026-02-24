

using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();
var services = builder.Services;
var configuration = builder.Configuration;
services.AddControllers();
services.AddEndpointsApiExplorer();

var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

// Включаем Swagger с XML-комментариями
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "My Notes API", 
        Version = "v1",
        Description = "API для управления заметками с полной документацией"
    });
    
    // Подключаем XML-файл
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath);
    
});


var app = builder.Build();


app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Notes API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


























