[<RequireQualifiedAccess>]
module Newishfs.Home

open System
open Microsoft.AspNetCore.Builder

let getNumbers =
    let getNumbers () = [ 1; 2; 3; 4; 5 ]
    Func<int list>(getNumbers)


let registerRoutes (app: WebApplication) =

    app.MapGet("/", getNumbers) |> ignore
    app
