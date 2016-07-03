module MathJS.Util

open System
open Fable.Core


type Result<'TSuccess, 'TError> = 
    | Success of 'TSuccess 
    | Error of 'TError list
    with 
    member this.apply fn =
        match (fn, this) with
        | Success(f), Success(x) -> Success(f x)
        | Error(e), Success(_) -> Error(e)
        | Success(_), Error(e) -> Error(e)
        | Error(e1), Error(e2) -> Error(List.concat [e1;e2])
    member this.bind f = 
        match this with 
            | Success s ->  f s
            | Error e -> Error e
    member this.map f =
        match this with
            | Success(s) -> Success(f s)
            | Error(e) -> Error e
    member this.join r =
        match r with
            | Success(s) -> 
                match s with
                    | Success(really) -> Success(really)
                    | Error(e) -> Error(e)
            | Error(e) -> Error e

let fromOption<'T> (defaultVal:'T) (o: 'T option) : 'T = if o.IsSome then o.Value else defaultVal

let checkSizeAndTransform (size: int) transformer err xs = if List.length xs <> size then Error(err(List.length xs)) else Success(transformer xs)

let fail f x = [f x]

let asSeq xs = xs |> List.map List.toSeq |> List.toSeq

let asList xs = xs |> Seq.map Seq.toList |> Seq.toList

let asResizeArray (xs:seq<seq<'a>>) = xs |> Seq.map ResizeArray |> ResizeArray

let inline (|>>=) (t:^T) (f: ^U -> ^T) = (^T : (member bind : (^U -> ^T) -> ^T) (t, f)) 

let inline (<!>) (f : ^A -> ^B) (t : ^T) : ^U = (^T : (member map : (^A -> ^B) -> ^U) (t, f))

let inline (<*>) (f: ^B) (t:^A) : ^C = (^A : (member apply : ^B -> ^C) (t, f)) 

let inline lift2 f a b = f <!> a <*> b
let inline lift3 f a b c = f <!> a <*> b <*> c
let inline lift4 f a b c d = f <!>  a <*> b <*> c <*> d
let inline lift5 f a b c d e = f <!>  a <*> b <*> c <*> d <*> e

let inline join (t:^T) : ^U = (^T : (member join : ^T -> ^U) (t,t))    

let inline show< ^T when ^T : (member show : unit -> String)> (x:^T) : string =
    (^T : (member show : unit -> string) (x))
    