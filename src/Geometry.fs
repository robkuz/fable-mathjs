module MathJS.Geometry

open Fable.Core
open Fable.Import.MathJS
open MathJS.Util

type Point2D = Point2D of float * float
type Line = Line of Point2D * Point2D
type InvalidSize = InvalidSize of int

let defaultPoint2D = Point2D(0.0, 0.0)
let defaultLine = Line(defaultPoint2D, defaultPoint2D)

let toPoint2D xs = 
    let asPoint = function
        | x::y::[] -> Point2D(x,y)
    let invalidSize x = [InvalidSize x]
    checkSizeAndTransform 2 asPoint invalidSize xs

let toList = function
    | Point2D(x, y) -> [x; y]

let convert = toList >> ResizeArray

let distance p1 p2 = 
    staticfn.distance((convert p1), (convert p2))

let intersect (Line(a1, a2)) (Line(b1, b2)) =
    let result = 
        let result = staticfn.intersect((convert a1), (convert a2), (convert b1), (convert b2))
        if result <> null then result else ResizeArray []
    result 
        |> Seq.toList
        |> toPoint2D