using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Newish;

var app = WebApplication
    .CreateBuilder(args)
    .Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .RegisterHomeRoutes()
    .RegisterTodoRoutes();

await app.RunAsync();