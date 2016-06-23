[<NUnit.Framework.TestFixture>] 
module MathJS.Test.Matrix

open System
open NUnit.Framework
open MathJS.Matrix
open MathJS.Util

let check msg (a: 't) (b:'t) = Assert.AreEqual(a, b, msg)

[<NUnit.Framework.TestFixture>] 
type ``creation tests``()=
    [<Test>]
    let checkSizeTestSuccess() =
        let d = [[1;2];[3;4]]
        let r = checkSizes d
        let result = r = (Success (2,2))

        check "(Success (2,2))" result true

    [<Test>]
    let checkSizeTestErrorEmpty() =
        let d = [[1;2];[]]
        let r = checkSizes d
        let result = r = (Error (fail InvalidRowSize 1))

        check "(Success (2,2))" result true

    [<Test>]
    let checkSizeTestErrorNotSame() =
        let d = [[1;2];[1;2];[1]]
        let r = checkSizes d
        let result = r = (Error (fail InvalidRowSize 2))

        check "(Success (2,2))" result true

    [<Test>]
    let makeSuccess() =
        let d = make [[1.0;2.0];[1.0;2.0];[1.0;2.0]]
        let s = asSeq [[1.0;2.0];[1.0;2.0];[1.0;2.0]]
        let result = d = (Success(Matrix(s, (3,2))))

        check "(Success([[1;2];[1;2];[1;2]], (2,3)))" result true

[<NUnit.Framework.TestFixture>]
type ``simple functions``()=
    [<Test>]
    let eyeTest() =
        let e1 = getData (eye 3 3) |> asList
        let e2 = getData (eye1 3) |> asList
        let e3 = getData (eye 2 3) |> asList
        let r1 = [[1.0; 0.0; 0.0]; [0.0; 1.0; 0.0]; [0.0; 0.0; 1.0]]
        let r3 = [[1.0; 0.0; 0.0]; [0.0; 1.0; 0.0]]
        let result1 = e1 = r1
        let result2 = e2 = r1
        let result3 = e3 = r3
        check "should be [[1.0, 0.0, 0.0], [0.0, 1.0, 0.0], [0.0, 0.0, 1.0]]" result1 true
        check "should be [[1.0, 0.0, 0.0], [0.0, 1.0, 0.0], [0.0, 0.0, 1.0]]" result2 true
        check "should be [[1.0, 0.0, 0.0], [0.0, 1.0, 0.0]]" result3 true

    [<Test>]
    let zeroTest() =
        let e1 = getData (zeros 2 2) |> asList
        let e2 = getData (zeros1 2) |> asList
        let e3 = getData (zeros 1 3) |> asList
        let r1 = [[0.0; 0.0]; [0.0; 0.0]]
        let r3 = [[0.0; 0.0; 0.0]]
        let result1 = e1 = r1
        let result2 = e2 = r1
        let result3 = e3 = r3
        check "should be [[1.0, 0.0], [0.0, 1.0]]" result1 true
        check "should be [[1.0, 0.0], [0.0, 1.0]]" result2 true
        check "should be [[1.0, 0.0]]" result3 true


    [<Test>]
    let oneTest() =
        let e1 = getData (ones 2 2) |> asList
        let e2 = getData (ones1 2) |> asList
        let e3 = getData (ones 1 3) |> asList
        let r1 = [[1.0; 1.0]; [1.0; 1.0]]
        let r3 = [[1.0; 1.0; 1.0]]

        let result1 = e1 = r1
        let result2 = e2 = r1
        let result3 = e3 = r3
        check "should be [[1.0; 1.0]; [1.0; 1.0]]" result1 true
        check "should be [[1.0; 1.0]; [1.0; 1.0]]" result2 true
        check "should be [[1.0; 1.0; 1.0]]" result3 true
    
    [<Test>]
    let errorSquareMatrixExpected() =
        let m1 = make [[1.0; 2.0; 3.0]; [1.0; 2.0; 3.0]]
        let init = det <!> m1 |> join
        let result = init = Error([SquareMatrixExpected])
        check "should be SquareMatrixExpected" result true
    
    [<Test>]
    let detTest() =
        let m1 = make [[-2.0; 2.0; 3.0]; [-1.0; 1.0; 3.0]; [2.0; 0.0; -1.0]]
        let init = det <!> m1 |> join
        let result = init = Success(6.0)
        check "should be success" result true

    [<Test>]
    let traceTest() =
        let m1 = make [[1.0; 2.0; 3.0]; [-1.0; 2.0; 3.0]; [2.0; 0.0; 3.0]]
        let init = trace <!> m1 |> join
        let result = init = Success(6.0)
        check "should be success" result true

    [<Test>]
    let invTest() =
        let m1 = make [[1.0; 2.0]; [3.0; 4.0]]
        let init = (getData >> asList) <!> (inv <!> m1 |> join)  
        let result = init = Success ([[-2.0; 1.0]; [1.5; -0.5]])
        check "should be success" result true

    [<Test>]
    let transposeTest() =
        let m1 = make [[1.0; 2.0; 3.0]; [4.0; 5.0; 6.0]]
        let init = (getData >> asList) <!> (transpose <!> m1)  
        let result = init = Success ([[1.0; 4.0]; [2.0; 5.0]; [3.0; 6.0]])
        check "should be success" result true

    [<Test>]
    let diagTest() =
        let m1 = make [[1.0; 2.0; 3.0]; [-1.0; 2.0; 3.0]; [2.0; 0.0; 3.0]]
        let init = (getData >> asList) <!> (diag <!> m1 |> join)
        let result = init = Success ([[1.0; 2.0; 3.0]])
        check "should be success" result true

    [<Test>]
    let flattenTest() =
        let m1 = make [[1.0; 2.0; 3.0]; [4.0; 5.0; 6.0]]
        let init = (getData >> asList) <!> (flatten <!> m1)
        let result = init = Success ([[1.0; 2.0; 3.0; 4.0; 5.0; 6.0]])
        check "should be success" result true

[<NUnit.Framework.TestFixture>]
type ``dot checks``()=

    [<Test>]
    let invalidVectorSize() =
        let m1 = make [[1.0; 2.0; 3.0; 4.0]]
        let m2 = make [[1.0; 2.0; 3.0]]
        let init = dot <!> m1 <*> m2 |> join
        let result = init = Error([InvalidMatrixSize(4,3)])
        check "should be InvalidMatrixSize" result true

    [<Test>]
    let invalidVectorsExpected() =
        let m1 = make [[1.0; 2.0; 3.0; 4.0];[1.0; 2.0; 3.0; 4.0]]
        let m2 = make [[1.0; 2.0; 3.0; 4.0];[1.0; 2.0; 3.0; 4.0]]
        let init = dot <!> m1 <*> m2 |> join
        let result = init = Error([VectorsExpected])
        check "should be VectorsExpected" result true

    [<Test>]
    let success() =
        let m1 = make [[1.0; 2.0; 3.0; 4.0]]
        let m2 = make [[1.0; 2.0; 3.0; 4.0]]
        let init = dot <!> m1 <*> m2 |> join
        let result = init = Success(30.0)
        check "should be VectorsExpected" result true


