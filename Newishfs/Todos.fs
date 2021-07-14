[<RequireQualifiedAccess>]
module Newishfs.Todos

open System
open Microsoft.AspNetCore.Builder

type Todo =
    { id: int
      title: string
      isDone: bool }

let mutable private todos = []

let getTodos =
    let getTodos () = todos |> List.toSeq
    Func<Todo seq>(getTodos)

let addTodo =
    let addTodo (todo: Todo) =
        todos <- todo :: todos
        true

    Func<Todo, bool>(addTodo)


let registerRoutes (app: WebApplication) =
    app.MapGet("/todos", getTodos) |> ignore
    app.MapPost("/todos", addTodo) |> ignore
    app
