[<NUnit.Framework.TestFixture>] 
module MathJS.Test.Geometry

open System
open MathJS.Geometry
open MathJS.Util
open NUnit.Framework

let check msg (a: 't) (b:'t) = Assert.AreEqual(a, b, msg)

[<Test>]
let distanceTest() =
    let p1 = Point2D(0.0, 0.0)
    let p2 = Point2D(4.0, 3.0)
    let p3 = Point2D(0.0, 0.0)

    check "should be 5.0" (distance p1 p2) 5.0
    check "should be 0.0" (distance p3 p1) 0.0

[<Test>]
let toPointTestSuccess() =
    let pr = toPoint2D [2.0; 4.0]
    let r = pr = (Success(Point2D(2.0, 4.0)))
    check "should be Point2D(2.0, 4.0)" r true

[<Test>]
let toPointTestError() =
    let pr = toPoint2D [2.0; 4.0; 6.0]
    let r = pr = Error([InvalidSize(3)])
    check "should be Error(InvalidSize(3))" r true

[<Test>]
let intersectTestSuccess() =
    let l1 = Line(Point2D(3.0, 6.0), Point2D(4.0, 7.0))
    let l2 = Line(Point2D(2.0, 8.0), Point2D(10.0, 8.0))
    let rp = intersect l1 l2
    let r = rp = Success(Point2D(5.0, 8.0))
    check "should be intersect at 5.0 8.0" r true

[<Test>]
let intersectTestError() =
    let l2 = Line(Point2D(2.0, 8.0), Point2D(10.0, 8.0))
    let l3 = Line(Point2D(2.0, 8.0), Point2D(10.0, 8.0)) 
    let rp = intersect l2 l3
    let r = rp = Error([InvalidSize(0)])
    check "should not intersect" r true
    //Assert.assert "should not intersect" $ (intersect l2 l2) == Nothing
