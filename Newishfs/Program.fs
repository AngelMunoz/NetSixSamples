module Program

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Newishfs

[<EntryPoint>]
let main args =
    let app =
        let builder = WebApplication.CreateBuilder(args)
        builder
            .Services
            .AddSingleton<Todos.ITodoService>(fun _ -> Todos.TodoService) |> ignore
        builder.Build()

    if app.Environment.IsDevelopment() then
        app.UseDeveloperExceptionPage() |> ignore

    app
    |> Home.registerRoutes
    |> Todos.registerRoutes
    |> ignore

    app.Run()
    0
