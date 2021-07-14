[<RequireQualifiedAccess>]
module Newishfs.Todos

open System
open Microsoft.AspNetCore.Builder

type Todo =
    { id: int
      title: string
      isDone: bool }
let mutable private todos = []

type ITodoService = 
    abstract GetTodos: unit -> Todo seq

let TodoService = { new ITodoService with
                        member this.GetTodos(): seq<Todo> = 
                            todos |> List.toSeq }
let private getTodos =
    Func<ITodoService, Todo seq>
        (fun (todos: ITodoService) -> todos.GetTodos())

let private addTodo =
    Func<Todo, bool>
        (fun todo ->
            todos <- todo :: todos
            true)

let registerRoutes (app: WebApplication) =
    app.MapGet("/todos", getTodos) |> ignore
    app.MapPost("/todos", addTodo) |> ignore
    app
