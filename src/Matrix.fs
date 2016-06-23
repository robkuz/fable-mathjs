module MathJS.Matrix

open System
open Fable.Core
open Fable.Import.MathJS
open Fable.Import.MathJS.mathjs
open MathJS.Util

type Numbers = seq<seq<float>>
type Sizes = int * int

(*
--foreign import _cross :: forall e. e -> MatrixF

-- missing
-- add
-- subtract
-- multiply
-- divide
*)


type Matrix = Matrix of Numbers * Sizes

type MatrixError =
    | VectorsExpected
    | InvalidMatrixSize of int * int
    | InvalidRowSize of int
    | SquareMatrixExpected
    | UnexpectedError


let asSizeSeq xs = xs |> Seq.toList |> List.map (fun x -> x |> Seq.toList |> List.length) 

let toSize xs =
    let rows = xs |> List.length
    let cols = match xs with
        | i::_ | i::[] -> i 
        | _ -> 0
    (rows, cols)

let same xs = xs |> List.forall (fun x -> (List.head xs) = x)       

let checkSizes xs =
    let sizes = asSizeSeq xs
    let isSame = same sizes
    let isZero x = x = 0
    let hasEmptyRows = sizes |> List.exists isZero
    let errIndex xs = xs |> List.findIndex (fun x -> isZero x || x <> List.head xs) 
    match (hasEmptyRows, isSame) with
        | (false, true) -> Success (toSize sizes)
        | (_, _) -> Error [(InvalidRowSize (errIndex sizes))]


let make a =
    let xs = asSeq a
    match checkSizes a with 
        | Success(x,y) -> Success(Matrix(xs, (x,y)))
        | Error(e) -> Error(e)

let getData (Matrix(a,_)) = a
let getSizes (Matrix(_,(x,y))) = (x,y)

let asSizes xs =
    match Seq.toList xs with 
        | f::s::[] -> (f, s)
        | _ -> (0,0)

let fromMatrixF (m:MatrixF) = Matrix(m._data, (asSizes m._size))

let fromArray a = Matrix(a, (asSizeSeq >> toSize) a)
let seqToMatrix xs = xs |> (asList >> asSeq >> fromArray)

let eye x y = 
    let init = staticfn.eye(x, y)
    fromMatrixF init

let eye1 x = eye x x

let zeros x y = fromMatrixF (staticfn.zeros(x, y))
let zeros1 x = zeros x x

let ones x y = fromMatrixF (staticfn.ones(x, y))
let ones1 x = ones x x

let dot (Matrix(a, (ax, ay))) (Matrix(b, (bx, by))) =
    let va = Seq.head a |> ResizeArray  
    let vb = Seq.head b |> ResizeArray  
    match (ax, bx, ay, by) with
    | (ax', bx', _, _) when ax <> 1 && bx <> 1  -> Error([VectorsExpected]) 
    | (_, _, ay', by') when ay <> by            -> Error([InvalidMatrixSize(ay,by)]) 
    | _                                         -> Success(staticfn.dot(va,vb))

let private squareMatrixFnStub f = fun (Matrix(a, (x,y))) -> if x = y then Success (f (asResizeArray a)) else Error [SquareMatrixExpected]

let det = squareMatrixFnStub staticfn.det

let trace = squareMatrixFnStub staticfn.trace

let inv = squareMatrixFnStub (staticfn.inv >> seqToMatrix)

let transpose = getData >> asResizeArray >> staticfn.transpose >> seqToMatrix

let diag = squareMatrixFnStub (staticfn.diag >> Seq.toList >> List.singleton >> seqToMatrix)

let flatten (Matrix(a, _)) = a |> Seq.concat |> Seq.singleton |> seqToMatrix