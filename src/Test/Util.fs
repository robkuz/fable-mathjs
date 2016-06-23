[<NUnit.Framework.TestFixture>] 
module MathJS.Test.Util

open System
open MathJS.Util
open NUnit.Framework

let check msg (a: 't) (b:'t) = Assert.AreEqual(a, b, msg)

[<Test>]
let fromOptionTest() =
    let s = Some 1
    check "should be 1" (fromOption 2 s) 1
    check "should be 2" (fromOption 2 None) 2

type Fail<'T> = Fail of 'T

let show = function
    | Success(s) -> sprintf ">>>Success(%A)" s
    | Error(e) -> sprintf "Error(%A)" e 

[<Test>]
let checkSizeAndTransformSuccess() =
    let s = Some 1
    let id a = a
    let r = checkSizeAndTransform 2 id (fail Fail) [1;2]
    let isOK = r = Success([1;2])
    check "Success([1;2])" isOK true

[<Test>]
let checkSizeAndTransformError() =
    let s = Some 1
    let id a = a
    let r = checkSizeAndTransform 2 id (fail Fail) [1;2;3]
    let hasFailed = r = Error((fail Fail) 3)
    check "Error(Fail(3))" hasFailed true

(*
type Baz = Baz of int with
    member this.bind (f: 'a -> 'b): 'b = match this with | Baz i ->  f i

type Foo = Foo of string with
    member this.bind (f: 'a -> 'b): 'b = match this with | Foo i ->  f i

let x = (Baz 1) |>>=fun x -> Baz (x+1)  
let y = (Foo "yeah")
            |>>= fun x -> Foo(x+"?") 
            |>>= fun x -> Foo(x+"!")   

Console.WriteLine (sprintf "%A" y)
*)