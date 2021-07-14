module Program

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Newishfs

[<EntryPoint>]
let main args =
    let app =
        WebApplication.CreateBuilder(args).Build()

    if app.Environment.IsDevelopment() then
        app.UseDeveloperExceptionPage() |> ignore

    app
    |> Home.registerRoutes
    |> Todos.registerRoutes
    |> ignore

    app.Run()
    0
