module Main

open System

open Fable.Core

open MathJS.Geometry


[<EntryPoint>]
let main argv =
    if argv.Length = 0 then
        printfn "Please provide an argument"
        1
    else
        0
