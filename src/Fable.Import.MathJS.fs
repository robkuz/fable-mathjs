module Fable.Import.MathJS

open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<Import("*","mathjs")>]
module mathjs =
    type MatrixF = {_data: seq<seq<float>>; _size: seq<int>}

    and InternalMatrix = ResizeArray<ResizeArray<float>>

    and MathArray = 
        U2<ResizeArray<float>, InternalMatrix>

    and Vector = ResizeArray<float>

    and MathType =
        U6<float, BigNumber, Fraction, Complex, MathArray, Matrix>

    and MathExpression =
        U4<string, ResizeArray<string>, MathArray, Matrix>

    and IMathJsStatic =
        abstract e: float with get, set
        abstract pi: float with get, set
        abstract uninitialized: obj with get, set
        abstract expression: MathNode with get, set
        abstract config: options: obj -> unit
        abstract lsolve: L: U2<Matrix, MathArray> * b: U2<Matrix, MathArray> -> U2<Matrix, MathArray>
        abstract lup: ?A: U2<Matrix, MathArray> -> MathArray
        abstract lusolve: A: U3<Matrix, MathArray, float> * b: U2<Matrix, MathArray> -> U2<Matrix, MathArray>
        abstract slu: A: Matrix * order: float * threshold: float -> obj
        abstract usolve: U: U2<Matrix, MathArray> * b: U2<Matrix, MathArray> -> U2<Matrix, MathArray>
        abstract abs: x: float -> float
        abstract abs: x: BigNumber -> BigNumber
        abstract abs: x: Fraction -> Fraction
        abstract abs: x: Complex -> Complex
        abstract abs: x: MathArray -> MathArray
        abstract abs: x: Matrix -> Matrix
        abstract abs: x: Unit -> Unit
        abstract add: x: MathType * y: MathType -> MathType
        abstract cbrt: x: float * ?allRoots: bool -> float
        abstract cbrt: x: BigNumber * ?allRoots: bool -> BigNumber
        abstract cbrt: x: Fraction * ?allRoots: bool -> Fraction
        abstract cbrt: x: Complex * ?allRoots: bool -> Complex
        abstract cbrt: x: MathArray * ?allRoots: bool -> MathArray
        abstract cbrt: x: Matrix * ?allRoots: bool -> Matrix
        abstract cbrt: x: Unit * ?allRoots: bool -> Unit
        abstract ceil: x: float -> float
        abstract ceil: x: BigNumber -> BigNumber
        abstract ceil: x: Fraction -> Fraction
        abstract ceil: x: Complex -> Complex
        abstract ceil: x: MathArray -> MathArray
        abstract ceil: x: Matrix -> Matrix
        abstract ceil: x: Unit -> Unit
        abstract cube: x: float -> float
        abstract cube: x: BigNumber -> BigNumber
        abstract cube: x: Fraction -> Fraction
        abstract cube: x: Complex -> Complex
        abstract cube: x: MathArray -> MathArray
        abstract cube: x: Matrix -> Matrix
        abstract cube: x: Unit -> Unit
        abstract divide: x: Unit * y: Unit -> Unit
        abstract divide: x: float * y: float -> float
        abstract divide: x: MathType * y: MathType -> MathType
        abstract dotDivide: x: MathType * y: MathType -> MathType
        abstract dotMultiply: x: MathType * y: MathType -> MathType
        abstract dotPow: x: MathType * y: MathType -> MathType
        abstract exp: x: float -> float
        abstract exp: x: BigNumber -> BigNumber
        abstract exp: x: Complex -> Complex
        abstract exp: x: MathArray -> MathArray
        abstract exp: x: Matrix -> Matrix
        abstract fix: x: float -> float
        abstract fix: x: BigNumber -> BigNumber
        abstract fix: x: Fraction -> Fraction
        abstract fix: x: Complex -> Complex
        abstract fix: x: MathArray -> MathArray
        abstract fix: x: Matrix -> Matrix
        abstract floor: x: float -> float
        abstract floor: x: BigNumber -> BigNumber
        abstract floor: x: Fraction -> Fraction
        abstract floor: x: Complex -> Complex
        abstract floor: x: MathArray -> MathArray
        abstract floor: x: Matrix -> Matrix
        abstract gcd: [<ParamArray>] args: float[] -> float
        abstract gcd: [<ParamArray>] args: BigNumber[] -> BigNumber
        abstract gcd: [<ParamArray>] args: Fraction[] -> Fraction
        abstract gcd: [<ParamArray>] args: MathArray[] -> MathArray
        abstract gcd: [<ParamArray>] args: Matrix[] -> Matrix
        abstract hypot: [<ParamArray>] args: float[] -> float
        abstract hypot: [<ParamArray>] args: BigNumber[] -> BigNumber
        abstract lcm: a: float * b: float -> float
        abstract lcm: a: BigNumber * b: BigNumber -> BigNumber
        abstract lcm: a: MathArray * b: MathArray -> MathArray
        abstract lcm: a: Matrix * b: Matrix -> Matrix
        abstract log: x: U5<float, BigNumber, Complex, MathArray, Matrix> * ?``base``: U3<float, BigNumber, Complex> -> U5<float, BigNumber, Complex, MathArray, Matrix>
        abstract log10: x: float -> float
        abstract log10: x: BigNumber -> BigNumber
        abstract log10: x: Complex -> Complex
        abstract log10: x: MathArray -> MathArray
        abstract log10: x: Matrix -> Matrix
        abstract ``mod``: x: U5<float, BigNumber, Fraction, MathArray, Matrix> * y: U5<float, BigNumber, Fraction, MathArray, Matrix> -> U5<float, BigNumber, Fraction, MathArray, Matrix>
        abstract multiply: x: U2<MathArray, Matrix> * y: U2<MathArray, Matrix> -> Matrix
        abstract multiply: x: U2<MathArray, Matrix> * y: MathType -> Matrix
        abstract multiply: x: Unit * y: Unit -> Unit
        abstract multiply: x: float * y: float -> float
        abstract multiply: x: MathType * y: MathType -> MathType
        abstract norm: x: U5<float, BigNumber, Complex, MathArray, Matrix> * ?p: U3<float, BigNumber, string> -> U2<float, BigNumber>
        abstract nthRoot: a: U5<float, BigNumber, MathArray, Matrix, Complex> * ?root: U2<float, BigNumber> -> U4<float, Complex, MathArray, Matrix>
        abstract pow: x: U5<float, BigNumber, Complex, MathArray, Matrix> * y: U3<float, BigNumber, Complex> -> U5<float, BigNumber, Complex, MathArray, Matrix>
        abstract round: x: MathType * ?n: U3<float, BigNumber, MathArray> -> MathType
        abstract sign: x: float -> float
        abstract sign: x: BigNumber -> BigNumber
        abstract sign: x: Fraction -> Fraction
        abstract sign: x: Complex -> Complex
        abstract sign: x: MathArray -> MathArray
        abstract sign: x: Matrix -> Matrix
        abstract sign: x: Unit -> Unit
        abstract sqrt: x: float -> float
        abstract sqrt: x: BigNumber -> BigNumber
        abstract sqrt: x: Complex -> Complex
        abstract sqrt: x: MathArray -> MathArray
        abstract sqrt: x: Matrix -> Matrix
        abstract sqrt: x: Unit -> Unit
        abstract square: x: float -> float
        abstract square: x: BigNumber -> BigNumber
        abstract square: x: Fraction -> Fraction
        abstract square: x: Complex -> Complex
        abstract square: x: MathArray -> MathArray
        abstract square: x: Matrix -> Matrix
        abstract square: x: Unit -> Unit
        abstract subtract: x: MathType * y: MathType -> MathType
        abstract unaryMinus: x: float -> float
        abstract unaryMinus: x: BigNumber -> BigNumber
        abstract unaryMinus: x: Fraction -> Fraction
        abstract unaryMinus: x: Complex -> Complex
        abstract unaryMinus: x: MathArray -> MathArray
        abstract unaryMinus: x: Matrix -> Matrix
        abstract unaryMinus: x: Unit -> Unit
        abstract unaryPlus: x: float -> float
        abstract unaryPlus: x: BigNumber -> BigNumber
        abstract unaryPlus: x: Fraction -> Fraction
        abstract unaryPlus: x: string -> string
        abstract unaryPlus: x: Complex -> Complex
        abstract unaryPlus: x: MathArray -> MathArray
        abstract unaryPlus: x: Matrix -> Matrix
        abstract unaryPlus: x: Unit -> Unit
        abstract xgcd: a: U2<float, BigNumber> * b: U2<float, BigNumber> -> MathArray
        abstract bitAnd: x: U4<float, BigNumber, MathArray, Matrix> * y: U4<float, BigNumber, MathArray, Matrix> -> U4<float, BigNumber, MathArray, Matrix>
        abstract bitNot: x: float -> float
        abstract bitNot: x: BigNumber -> BigNumber
        abstract bitNot: x: MathArray -> MathArray
        abstract bitNot: x: Matrix -> Matrix
        abstract bitOr: x: float -> float
        abstract bitOr: x: BigNumber -> BigNumber
        abstract bitOr: x: MathArray -> MathArray
        abstract bitOr: x: Matrix -> Matrix
        abstract bitXor: x: U4<float, BigNumber, MathArray, Matrix> * y: U4<float, BigNumber, MathArray, Matrix> -> U4<float, BigNumber, MathArray, Matrix>
        abstract leftShift: x: U4<float, BigNumber, MathArray, Matrix> * y: U2<float, BigNumber> -> U4<float, BigNumber, MathArray, Matrix>
        abstract rightArithShift: x: U4<float, BigNumber, MathArray, Matrix> * y: U2<float, BigNumber> -> U4<float, BigNumber, MathArray, Matrix>
        abstract rightLogShift: x: U3<float, MathArray, Matrix> * y: float -> U3<float, MathArray, Matrix>
        abstract bellNumbers: n: float -> float
        abstract bellNumbers: n: BigNumber -> BigNumber
        abstract catalan: n: float -> float
        abstract catalan: n: BigNumber -> BigNumber
        abstract composition: n: U2<float, BigNumber> * k: U2<float, BigNumber> -> U2<float, BigNumber>
        abstract stirlingS2: n: U2<float, BigNumber> * k: U2<float, BigNumber> -> U2<float, BigNumber>
        abstract arg: x: float -> float
        abstract arg: x: Complex -> float
        abstract arg: x: MathArray -> MathArray
        abstract arg: x: Matrix -> Matrix
        abstract conj: x: U5<float, BigNumber, Complex, MathArray, Matrix> -> U5<float, BigNumber, Complex, MathArray, Matrix>
        abstract im: x: U5<float, BigNumber, Complex, MathArray, Matrix> -> U4<float, BigNumber, MathArray, Matrix>
        abstract re: x: U5<float, BigNumber, Complex, MathArray, Matrix> -> U4<float, BigNumber, MathArray, Matrix>
        abstract bignumber: ?x: U5<float, string, MathArray, Matrix, bool> -> BigNumber
        abstract boolean: x: U5<string, float, bool, MathArray, Matrix> -> U3<bool, MathArray, Matrix>
        abstract chain: ?value: obj -> IMathJsChain
        abstract complex: unit -> Complex
        abstract complex: re: float * im: float -> Complex
        abstract complex: complex: Complex -> Complex
        abstract complex: arg: string -> Complex
        abstract complex: array: MathArray -> Complex
        abstract complex: obj: IPolarCoordinates -> Complex
        abstract fraction: numerator: U4<float, string, MathArray, Matrix> * ?denominator: U4<float, string, MathArray, Matrix> -> U3<Fraction, MathArray, Matrix>
        abstract index: [<ParamArray>] ranges: obj[] -> Index
        abstract matrix: ?format: string -> Matrix
        abstract matrix: data: U2<MathArray, Matrix> * ?format: string * ?dataType: string -> Matrix
        abstract number: ?value: MathType -> U3<float, MathArray, Matrix>
        abstract number: unit: Unit * valuelessUnit: U2<Unit, string> -> U3<float, MathArray, Matrix>
        abstract sparse: ?data: U2<MathArray, Matrix> * ?dataType: string -> Matrix
        abstract string: value: obj -> U3<string, MathArray, Matrix>
        abstract unit: unit: string -> Unit
        abstract unit: value: float * unit: string -> Unit
        abstract compile: expr: MathExpression -> EvalFunction
        abstract compile: exprs: ResizeArray<MathExpression> -> ResizeArray<EvalFunction>
        abstract eval: expr: MathExpression * ?scope: obj -> obj
        abstract eval: exprs: ResizeArray<MathExpression> * ?scope: obj -> obj
        abstract help: search: obj -> Help
        abstract parse: expr: MathExpression * ?options: obj -> MathNode
        abstract parse: exprs: ResizeArray<MathExpression> * ?options: obj -> ResizeArray<MathNode>
        abstract parser: unit -> Parser
        abstract distance: x: Vector * y: Vector -> float
        abstract intersect: w: Vector * x: Vector * y: Vector * z: Vector -> Vector
        abstract ``and``: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract not: x: MathType -> U3<bool, MathArray, Matrix>
        abstract ``or``: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract xor: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract concat: [<ParamArray>] args: U3<MathArray, Matrix, float>[] -> U2<MathArray, Matrix>
        abstract cross: x: U2<MathArray, Matrix> * y: U2<MathArray, Matrix> -> Matrix
        abstract det: x: InternalMatrix -> float
        abstract diag: X: InternalMatrix -> Vector
        abstract diag: X: U2<MathArray, Matrix> * k: U2<float, BigNumber> * ?format: string -> Matrix
        abstract dot: x: ResizeArray<float> * y: ResizeArray<float> -> float
        abstract eye: m: int * n: int * ?format: string -> MatrixF
        abstract flatten: x: U2<MathArray, Matrix> -> U2<MathArray, Matrix>
        abstract inv: x: InternalMatrix -> InternalMatrix
        abstract ones: m: int * n: int * ?format: string -> MatrixF
        abstract range: str: string * ?includeEnd: bool -> Matrix
        abstract range: start: U2<float, BigNumber> * ``end``: U2<float, BigNumber> * ?includeEnd: bool -> Matrix
        abstract range: start: U2<float, BigNumber> * ``end``: U2<float, BigNumber> * step: U2<float, BigNumber> * ?includeEnd: bool -> Matrix
        abstract resize: x: U2<MathArray, Matrix> * size: U2<MathArray, Matrix> * ?defaultValue: U2<float, string> -> U2<MathArray, Matrix>
        abstract size: x: MathType -> U2<MathArray, Matrix>
        abstract squeeze: x: U2<MathArray, Matrix> -> U2<Matrix, MathArray>
        abstract subset: value: U3<MathArray, Matrix, string> * index: Index * ?replacement: obj * ?defaultValue: obj -> U3<MathArray, Matrix, string>
        abstract trace: x: InternalMatrix -> float
        abstract transpose: x: InternalMatrix -> InternalMatrix
        abstract zeros: m: int * n: int * ?format: string -> MatrixF
        abstract combinations: n: U2<float, BigNumber> * k: U2<float, BigNumber> -> U2<float, BigNumber>
        abstract distribution: name: string -> Distribution
        abstract factorial: n: U4<float, BigNumber, MathArray, Matrix> -> U4<float, BigNumber, MathArray, Matrix>
        abstract gamma: n: U3<float, MathArray, Matrix> -> U3<float, MathArray, Matrix>
        abstract kldivergence: x: U2<MathArray, Matrix> * y: U2<MathArray, Matrix> -> float
        abstract multinomial: a: U2<ResizeArray<float>, ResizeArray<BigNumber>> -> U2<float, BigNumber>
        abstract permutations: n: U2<float, BigNumber> * ?k: U2<float, BigNumber> -> U2<float, BigNumber>
        abstract pickRandom: array: ResizeArray<float> -> float
        abstract random: unit -> float
        abstract random: max: float -> float
        abstract random: min: float * max: float -> float
        abstract random: size: U2<MathArray, Matrix> * ?max: float -> U2<MathArray, Matrix>
        abstract random: size: U2<MathArray, Matrix> * min: float * max: float -> U2<MathArray, Matrix>
        abstract randomInt: max: float -> float
        abstract randomInt: min: float * max: float -> float
        abstract randomInt: size: U2<MathArray, Matrix> * ?max: float -> U2<MathArray, Matrix>
        abstract randomInt: size: U2<MathArray, Matrix> * min: float * max: float -> U2<MathArray, Matrix>
        abstract compare: x: MathType * y: MathType -> U5<float, BigNumber, Fraction, MathArray, Matrix>
        abstract deepEqual: x: MathType * y: MathType -> MathType
        abstract equal: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract larger: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract largerEq: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract smaller: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract smallerEq: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract unequal: x: MathType * y: MathType -> U3<bool, MathArray, Matrix>
        abstract max: [<ParamArray>] args: MathType[] -> obj
        abstract max: A: U2<MathArray, Matrix> * ?dim: float -> obj
        abstract mean: [<ParamArray>] args: MathType[] -> obj
        abstract mean: A: U2<MathArray, Matrix> * ?dim: float -> obj
        abstract median: [<ParamArray>] args: MathType[] -> obj
        abstract min: [<ParamArray>] args: MathType[] -> obj
        abstract min: A: U2<MathArray, Matrix> * ?dim: float -> obj
        abstract mode: [<ParamArray>] args: MathType[] -> obj
        abstract prod: [<ParamArray>] args: MathType[] -> obj
        abstract quantileSeq: A: U2<MathArray, Matrix> * prob: U3<float, BigNumber, MathArray> * ?sorted: bool -> U4<float, BigNumber, Unit, MathArray>
        abstract std: array: U2<MathArray, Matrix> * ?normalization: string -> float
        abstract sum: [<ParamArray>] args: U3<float, BigNumber, Fraction>[] -> obj
        abstract sum: array: U2<MathArray, Matrix> -> obj
        abstract var: [<ParamArray>] args: U3<float, BigNumber, Fraction>[] -> obj
        abstract var: array: U2<MathArray, Matrix> * ?normalization: string -> obj
        abstract acos: x: float -> float
        abstract acos: x: BigNumber -> BigNumber
        abstract acos: x: Complex -> Complex
        abstract acos: x: MathArray -> MathArray
        abstract acos: x: Matrix -> Matrix
        abstract acosh: x: float -> float
        abstract acosh: x: BigNumber -> BigNumber
        abstract acosh: x: Complex -> Complex
        abstract acosh: x: MathArray -> MathArray
        abstract acosh: x: Matrix -> Matrix
        abstract acot: x: float -> float
        abstract acot: x: BigNumber -> BigNumber
        abstract acot: x: MathArray -> MathArray
        abstract acot: x: Matrix -> Matrix
        abstract acoth: x: float -> float
        abstract acoth: x: BigNumber -> BigNumber
        abstract acoth: x: MathArray -> MathArray
        abstract acoth: x: Matrix -> Matrix
        abstract acsc: x: float -> float
        abstract acsc: x: BigNumber -> BigNumber
        abstract acsc: x: MathArray -> MathArray
        abstract acsc: x: Matrix -> Matrix
        abstract acsch: x: float -> float
        abstract acsch: x: BigNumber -> BigNumber
        abstract acsch: x: MathArray -> MathArray
        abstract acsch: x: Matrix -> Matrix
        abstract asec: x: float -> float
        abstract asec: x: BigNumber -> BigNumber
        abstract asec: x: MathArray -> MathArray
        abstract asec: x: Matrix -> Matrix
        abstract asech: x: float -> float
        abstract asech: x: BigNumber -> BigNumber
        abstract asech: x: MathArray -> MathArray
        abstract asech: x: Matrix -> Matrix
        abstract asin: x: float -> float
        abstract asin: x: BigNumber -> BigNumber
        abstract asin: x: Complex -> Complex
        abstract asin: x: MathArray -> MathArray
        abstract asin: x: Matrix -> Matrix
        abstract asinh: x: float -> float
        abstract asinh: x: BigNumber -> BigNumber
        abstract asinh: x: MathArray -> MathArray
        abstract asinh: x: Matrix -> Matrix
        abstract atan: x: float -> float
        abstract atan: x: BigNumber -> BigNumber
        abstract atan: x: MathArray -> MathArray
        abstract atan: x: Matrix -> Matrix
        abstract atan2: y: float * x: float -> float
        abstract atan2: y: U2<MathArray, Matrix> * x: U2<MathArray, Matrix> -> U2<MathArray, Matrix>
        abstract atanh: x: float -> float
        abstract atanh: x: BigNumber -> BigNumber
        abstract atanh: x: MathArray -> MathArray
        abstract atanh: x: Matrix -> Matrix
        abstract asin: x: Unit -> float
        abstract cosh: x: float -> float
        abstract cosh: x: BigNumber -> BigNumber
        abstract cosh: x: Complex -> Complex
        abstract cosh: x: Unit -> float
        abstract cosh: x: MathArray -> MathArray
        abstract cosh: x: Matrix -> Matrix
        abstract cot: x: float -> float
        abstract cot: x: Complex -> Complex
        abstract cot: x: Unit -> float
        abstract cot: x: MathArray -> MathArray
        abstract cot: x: Matrix -> Matrix
        abstract coth: x: float -> float
        abstract coth: x: Complex -> Complex
        abstract coth: x: Unit -> float
        abstract coth: x: MathArray -> MathArray
        abstract coth: x: Matrix -> Matrix
        abstract csc: x: float -> float
        abstract csc: x: Complex -> Complex
        abstract csc: x: Unit -> float
        abstract csc: x: MathArray -> MathArray
        abstract csc: x: Matrix -> Matrix
        abstract csch: x: float -> float
        abstract csch: x: Complex -> Complex
        abstract csch: x: Unit -> float
        abstract csch: x: MathArray -> MathArray
        abstract csch: x: Matrix -> Matrix
        abstract sec: x: float -> float
        abstract sec: x: Complex -> Complex
        abstract sec: x: Unit -> float
        abstract sec: x: MathArray -> MathArray
        abstract sec: x: Matrix -> Matrix
        abstract sech: x: float -> float
        abstract sech: x: Complex -> Complex
        abstract sech: x: Unit -> float
        abstract sech: x: MathArray -> MathArray
        abstract sech: x: Matrix -> Matrix
        abstract sin: x: float -> float
        abstract sin: x: BigNumber -> BigNumber
        abstract sin: x: Complex -> Complex
        abstract sin: x: Unit -> float
        abstract sin: x: MathArray -> MathArray
        abstract sin: x: Matrix -> Matrix
        abstract sinh: x: float -> float
        abstract sinh: x: BigNumber -> BigNumber
        abstract sinh: x: Complex -> Complex
        abstract sinh: x: Unit -> float
        abstract sinh: x: MathArray -> MathArray
        abstract sinh: x: Matrix -> Matrix
        abstract tan: x: float -> float
        abstract tan: x: BigNumber -> BigNumber
        abstract tan: x: Complex -> Complex
        abstract tan: x: Unit -> float
        abstract tan: x: MathArray -> MathArray
        abstract tan: x: Matrix -> Matrix
        abstract tanh: x: float -> float
        abstract tanh: x: BigNumber -> BigNumber
        abstract tanh: x: Complex -> Complex
        abstract tanh: x: Unit -> float
        abstract tanh: x: MathArray -> MathArray
        abstract tanh: x: Matrix -> Matrix
        abstract ``to``: x: U3<Unit, MathArray, Matrix> * unit: U2<Unit, string> -> U3<Unit, MathArray, Matrix>
        abstract clone: x: obj -> obj
        abstract filter: x: U2<MathArray, Matrix> * test: U2<Regex, Func<obj, bool>> -> U2<MathArray, Matrix>
        abstract forEach: x: U2<MathArray, Matrix> * callback: Func<obj, obj> -> unit
        abstract format: value: obj * ?options: U3<IFormatOptions, float, Func<obj, string>> -> string
        abstract isInteger: x: obj -> bool
        abstract isNegative: x: obj -> bool
        abstract isNumeric: x: obj -> bool
        abstract isPositive: x: obj -> bool
        abstract isZero: x: obj -> bool
        abstract map: x: U2<MathArray, Matrix> * callback: Func<obj, obj> -> U2<MathArray, Matrix>
        abstract partitionSelect: x: U2<MathArray, Matrix> * k: float * ?compare: U2<string, Func<obj, obj, float>> -> obj
        abstract print: template: string * values: obj * ?precision: float -> unit
        abstract sort: x: U2<MathArray, Matrix> * ?compare: U2<string, Func<obj, obj, float>> -> U2<MathArray, Matrix>
        abstract typeof: x: obj -> string

    and Matrix =
        abstract size: unit -> ResizeArray<float>
        abstract subset: index: Index * ?replacement: obj * ?defaultValue: obj -> Matrix
        abstract resize: size: U2<MathArray, Matrix> * ?defaultValue: U2<float, string> -> Matrix
        abstract clone: unit -> Matrix

    and BigNumber =
        interface end

    and Fraction =
        interface end

    and Complex =
        abstract re: float with get, set
        abstract im: float with get, set
        abstract toPolar: unit -> IPolarCoordinates
        abstract clone: unit -> Complex

    and IPolarCoordinates =
        abstract r: float with get, set
        abstract phi: float with get, set

    and Unit =
        abstract ``to``: unit: string -> Unit
        abstract toNumber: unit: string -> float

    and Index =
        interface end

    and EvalFunction =
        abstract eval: ?scope: obj -> obj

    and MathNode =
        abstract isNode: bool with get, set
        abstract isSymbolNode: bool with get, set
        abstract ``type``: string with get, set
        abstract name: string with get, set
        abstract value: obj with get, set
        abstract compile: unit -> EvalFunction
        abstract eval: unit -> obj
        abstract eval: expr: string -> obj
        abstract filter: callback: Func<MathNode, string, MathNode, obj> -> ResizeArray<MathNode>
        abstract forEach: callback: Func<MathNode, string, MathNode, bool> -> ResizeArray<MathNode>
        abstract traverse: callback: Func<MathNode, string, MathNode, unit> -> obj
        abstract transform: callback: Func<MathNode, string, MathNode, bool> -> ResizeArray<MathNode>

    and Parser =
        abstract eval: expr: string -> obj
        abstract get: variable: string -> obj
        abstract set: variable: string * value: obj -> unit
        abstract clear: unit -> unit

    and Distribution =
        abstract random: size: obj * ?min: obj * ?max: obj -> obj
        abstract randomInt: min: obj * ?max: obj -> obj
        abstract pickRandom: array: obj -> obj

    and IFormatOptions =
        abstract notation: string option with get, set
        abstract precision: float option with get, set
        abstract exponential: obj option with get, set
        abstract fraction: string option with get, set
        abstract fn: Func<obj, string> option with get, set

    and Help =
        abstract toString: unit -> string
        abstract toJSON: unit -> string

    and IMathJsChain =
        abstract lsolve: b: U2<Matrix, MathArray> -> IMathJsChain
        abstract lup: unit -> IMathJsChain
        abstract lusolve: b: U2<Matrix, MathArray> -> IMathJsChain
        abstract slu: order: float * threshold: float -> IMathJsChain
        abstract usolve: b: U2<Matrix, MathArray> -> IMathJsChain
        abstract abs: unit -> IMathJsChain
        abstract add: y: MathType -> IMathJsChain
        abstract cbrt: ?allRoots: bool -> IMathJsChain
        abstract ceil: unit -> IMathJsChain
        abstract cube: unit -> IMathJsChain
        abstract divide: y: MathType -> IMathJsChain
        abstract dotDivide: y: MathType -> IMathJsChain
        abstract dotMultiply: y: MathType -> IMathJsChain
        abstract dotPow: y: MathType -> IMathJsChain
        abstract exp: unit -> IMathJsChain
        abstract fix: unit -> IMathJsChain
        abstract floor: unit -> IMathJsChain
        abstract gcd: [<ParamArray>] args: float[] -> IMathJsChain
        abstract gcd: [<ParamArray>] args: BigNumber[] -> IMathJsChain
        abstract gcd: [<ParamArray>] args: Fraction[] -> IMathJsChain
        abstract gcd: [<ParamArray>] args: MathArray[] -> IMathJsChain
        abstract gcd: [<ParamArray>] args: Matrix[] -> IMathJsChain
        abstract hypot: [<ParamArray>] args: float[] -> IMathJsChain
        abstract hypot: [<ParamArray>] args: BigNumber[] -> IMathJsChain
        abstract lcm: b: float -> IMathJsChain
        abstract lcm: b: BigNumber -> IMathJsChain
        abstract lcm: b: MathArray -> IMathJsChain
        abstract lcm: b: Matrix -> IMathJsChain
        abstract log: ?``base``: U3<float, BigNumber, Complex> -> IMathJsChain
        abstract log10: unit -> IMathJsChain
        abstract ``mod``: y: U5<float, BigNumber, Fraction, MathArray, Matrix> -> IMathJsChain
        abstract multiply: y: MathType -> IMathJsChain
        abstract norm: ?p: U3<float, BigNumber, string> -> IMathJsChain
        abstract nthRoot: ?root: U2<float, BigNumber> -> IMathJsChain
        abstract pow: y: U3<float, BigNumber, Complex> -> IMathJsChain
        abstract round: ?n: U3<float, BigNumber, MathArray> -> IMathJsChain
        abstract sign: unit -> IMathJsChain
        abstract sqrt: unit -> IMathJsChain
        abstract square: unit -> IMathJsChain
        abstract subtract: y: MathType -> IMathJsChain
        abstract unaryMinus: unit -> IMathJsChain
        abstract unaryPlus: unit -> IMathJsChain
        abstract xgcd: b: U2<float, BigNumber> -> IMathJsChain
        abstract bitAnd: y: U4<float, BigNumber, MathArray, Matrix> -> IMathJsChain
        abstract bitNot: unit -> IMathJsChain
        abstract bitOr: unit -> IMathJsChain
        abstract bitXor: y: U4<float, BigNumber, MathArray, Matrix> -> IMathJsChain
        abstract leftShift: y: U2<float, BigNumber> -> IMathJsChain
        abstract rightArithShift: y: U2<float, BigNumber> -> IMathJsChain
        abstract rightLogShift: y: float -> IMathJsChain
        abstract bellNumbers: unit -> IMathJsChain
        abstract catalan: unit -> IMathJsChain
        abstract composition: k: U2<float, BigNumber> -> IMathJsChain
        abstract stirlingS2: k: U2<float, BigNumber> -> IMathJsChain
        abstract arg: unit -> IMathJsChain
        abstract conj: unit -> IMathJsChain
        abstract im: unit -> IMathJsChain
        abstract re: unit -> IMathJsChain
        abstract distance: y: U3<MathArray, Matrix, obj> -> IMathJsChain
        abstract intersect: x: U2<MathArray, Matrix> * y: U2<MathArray, Matrix> * z: U2<MathArray, Matrix> -> IMathJsChain
        abstract ``and``: y: MathType -> IMathJsChain
        abstract not: unit -> IMathJsChain
        abstract ``or``: y: MathType -> IMathJsChain
        abstract xor: y: MathType -> IMathJsChain
        abstract cross: y: U2<MathArray, Matrix> -> IMathJsChain
        abstract det: unit -> IMathJsChain
        abstract resize: size: U2<MathArray, Matrix> * ?defaultValue: U2<float, string> -> IMathJsChain
        abstract size: unit -> IMathJsChain
        abstract squeeze: unit -> IMathJsChain
        abstract subset: index: Index * ?replacement: obj * ?defaultValue: obj -> IMathJsChain
        abstract trace: unit -> IMathJsChain
        abstract transpose: unit -> IMathJsChain
        abstract pickRandom: unit -> IMathJsChain
        abstract random: unit -> IMathJsChain
        abstract random: ?max: float -> IMathJsChain
        abstract random: min: float * max: float -> IMathJsChain
        abstract randomInt: ?max: float -> IMathJsChain
        abstract randomInt: min: float * max: float -> IMathJsChain
        abstract compare: y: MathType -> IMathJsChain
        abstract deepEqual: y: MathType -> IMathJsChain
        abstract equal: y: MathType -> IMathJsChain
        abstract larger: y: MathType -> IMathJsChain
        abstract largerEq: y: MathType -> IMathJsChain
        abstract smaller: IMathJsChainy: MathType -> IMathJsChain
        abstract smallerEq: IMathJsChainy: MathType -> IMathJsChain
        abstract unequal: IMathJsChainy: MathType -> IMathJsChain
        abstract max: ?dim: float -> IMathJsChain
        abstract mean: ?dim: float -> IMathJsChain
        abstract median: unit -> IMathJsChain
        abstract min: ?dim: float -> IMathJsChain
        abstract mode: unit -> IMathJsChain
        abstract prod: unit -> IMathJsChain
        abstract quantileSeq: prob: U3<float, BigNumber, MathArray> * ?sorted: bool -> IMathJsChain
        abstract std: ?normalization: string -> IMathJsChain
        abstract sum: unit -> IMathJsChain
        abstract var: ?normalization: string -> IMathJsChain
        abstract acos: unit -> IMathJsChain
        abstract acosh: unit -> IMathJsChain
        abstract acot: unit -> IMathJsChain
        abstract acoth: unit -> IMathJsChain
        abstract acsc: unit -> IMathJsChain
        abstract acsch: unit -> IMathJsChain
        abstract asec: unit -> IMathJsChain
        abstract asech: unit -> IMathJsChain
        abstract asin: unit -> IMathJsChain
        abstract asinh: unit -> IMathJsChain
        abstract atan: unit -> IMathJsChain
        abstract atan2: x: float -> IMathJsChain
        abstract atan2: x: U2<MathArray, Matrix> -> IMathJsChain
        abstract atanh: unit -> IMathJsChain
        abstract cosh: unit -> IMathJsChain
        abstract cot: unit -> IMathJsChain
        abstract coth: unit -> IMathJsChain
        abstract csc: unit -> IMathJsChain
        abstract csch: unit -> IMathJsChain
        abstract sec: unit -> IMathJsChain
        abstract sech: unit -> IMathJsChain
        abstract sin: unit -> IMathJsChain
        abstract sinh: unit -> IMathJsChain
        abstract tan: unit -> IMathJsChain
        abstract tanh: unit -> IMathJsChain
        abstract ``to``: unit: U2<Unit, string> -> IMathJsChain
        abstract clone: unit -> IMathJsChain
        abstract filter: test: U2<Regex, Func<obj, bool>> -> IMathJsChain
        abstract format: ?options: U3<IFormatOptions, float, Func<obj, string>> -> IMathJsChain
        abstract map: callback: Func<obj, obj> -> IMathJsChain
        abstract partitionSelect: k: float * ?compare: U2<string, Func<obj, obj, float>> -> IMathJsChain
        abstract sort: ?compare: U2<string, Func<obj, obj, float>> -> IMathJsChain
        abstract ``done``: unit -> obj
        abstract valueOf: unit -> obj
        abstract toString: unit -> string

let [<Import("*","mathjs")>] staticfn: mathjs.IMathJsStatic = failwith "JS only"

