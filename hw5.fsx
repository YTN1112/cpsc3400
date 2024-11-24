// Expression type (DO NOT MODIFY)
type Expression =
    | X
    | Y
    | Const of float
    | Neg of Expression
    | Add of Expression * Expression
    | Sub of Expression * Expression
    | Mul of Expression * Expression

// exprToString formatting function (DO NOT MODIFY)
let exprToString expr =
    let rec recExprStr parens expr =
        let lParen = if parens then "(" else ""
        let rParen = if parens then ")" else ""
        match expr with
        | X -> "x"
        | Y -> "y"
        | Const n -> n.ToString()
        | Neg e -> lParen + "-" + recExprStr true e + rParen
        | Add (e1, e2) -> lParen + recExprStr true e1 + "+" + recExprStr true e2 + rParen
        | Sub (e1, e2) -> lParen + recExprStr true e1 + "-" + recExprStr true e2 + rParen
        | Mul (e1, e2) -> lParen + recExprStr true e1 + "*" + recExprStr true e2 + rParen
    recExprStr false expr

// TODO: write simplify function
let rec simplify expr =
    match expr with
    | Mul (e1, e2) -> simplifyMul (simplify e1, simplify e2)
    | Add (e1, e2) -> simplifyAdd (simplify e1, simplify e2)
    | Sub (e1, e2) -> simplifySub (simplify e1, simplify e2)
    | Neg e -> simplifyNeg (simplify e)
    | _ -> expr

// Helper function for multiplication simplifications
and simplifyMul (e1, e2) =
    match (e1, e2) with
    | (e1, Const 0.0) -> Const 0.0
    | (Const 0.0, e2) -> Const 0.0
    | (e1, Const 1.0) -> e1
    | (Const 1.0, e2) -> e2
    | (Const a, Const b) -> Const (a * b)
    | _ -> Mul (e1, e2)  // Return simplified but unchanged structure if no further simplification

// Helper function for addition simplifications
and simplifyAdd (e1, e2) =
    match (e1, e2) with
    | (Const 0.0, e) | (e, Const 0.0) -> e
    | (Const a, Const b) -> Const (a + b)
    | _ -> Add (e1, e2)  // Return simplified but unchanged structure if no further simplification

// Helper function for subtraction simplifications
and simplifySub (e1, e2) =
    match (e1, e2) with
    | (e1, e2) when e1 = e2 -> Const 0.0 
    | (X, X) | (Y, Y) -> Const 0.0
    | (Const 0.0, Neg e) -> e // Exsample 0 -(-x) should simplify to 0+x
    | (Const 0.0, X) -> Neg X
    | (Const 0.0, Y) -> Neg Y
    | (X, Const 0.0) -> X
    | (Y, Const 0.0) -> Y
    | (Const 0.0, e) -> Neg e
    | (e, Const 0.0) -> e
    | (Const a, Const b) -> Const (a - b)
    | _ -> Sub (e1, e2)  // Return simplified but unchanged structure if no further simplification

// Helper function for negation simplifications
and simplifyNeg e =
    match simplify e with
    | Neg e_inner -> e_inner  // Immediately return the inner expression when negation is found
    | Const a -> Const (-a)  // Negate constants directly
    | e_simplified -> Neg e_simplified  // Apply negation to any other simplified expressio

// use helper functions for each of the operations
// add(e1,e2)->simplifyAdd
// It would detect expressions for each, two constants do this, constant and zero do this.
// expression and zero for this
// One you can't return, return unmodifed
// Then you have a catchall for each operations, and its easier to debug
// Base cases then catch all
// Then return expression for each call
// might need to call another function
// Split up into each
// can be done with 1 large block, but its harder to debug



// Provided Tests (DO NOT MODIFY)
printfn "---Provided Tests---"
let t1 = Add (Const 9.0, Const 4.0)
let t2 = Sub (Const 10.0, Const 3.5)
let t3 = Mul (Const 6.0, Const 7.0)
let t4 = Neg (Const 0.3)
let t5 = Neg (Const -9.0)
let t6 = Add (X, Const 0.0)
let t7 = Add (Const 0.0, Y)
let t8 = Sub (X, Const 0.0)
let t9 = Sub (Const 0.0, Y)
let t10 = Sub (Y, Y)
let t11 = Mul (X, Const 0.0)
let t12 = Mul (Const 0.0, Y)
let t13 = Mul (X, Const 1.0)
let t14 = Mul (Const 1.0, Y)
let t15 = Neg (Neg X)
let t16 = Sub (Mul (Const 1.0, X), Add (X, Const 0.0))
let t17 = Add (Sub (Const 3.0, Const 8.0), Mul (Const 7.0, Const 3.0))
let t18 = Sub (Sub (Add (Y, Const 3.0), Add (Y, Const 3.0)), Add (Const 0.0, Add (Y, Const 3.0)))
let t19 = Sub (Const 0.0, Neg (Mul (Const 1.0, X)))
let t20 = Mul (Add (X, Const 2.0), Neg (Sub (Mul (Const 2.0, Y), Const 5.0)))
let t21 = Add (Const 0.0, Const 0.0)
let t22 = Sub (Const 0.0, Const 0.0)
let t23 = Mul (Const 0.0, Const 0.0)
let t24 = Neg (Const 0.0)
let t25 = Add (X, X)
let t26 = Sub (X, X)
let t27 = Mul (X, X)
let t28 = Neg (X)
let t29 = Add (Y, Y)
let t30 = Sub (Y, Y)
let t31 = Mul (Y, Y)
let t32 = Neg (Y)

printfn "t1  Correct: 13\t\tActual: %s" (exprToString (simplify t1))
printfn "t2  Correct: 6.5\tActual: %s" (exprToString (simplify t2)) 
printfn "t3  Correct: 42\t\tActual: %s" (exprToString (simplify t3))
printfn "t4  Correct: -0.3\tActual: %s" (exprToString (simplify t4))
printfn "t5  Correct: 9\t\tActual: %s" (exprToString (simplify t5))
printfn "t6  Correct: x\t\tActual: %s" (exprToString (simplify t6))
printfn "t7  Correct: y\t\tActual: %s" (exprToString (simplify t7))
printfn "t8  Correct: x\t\tActual: %s" (exprToString (simplify t8))
printfn "t9  Correct: -y\t\tActual: %s" (exprToString (simplify t9))
printfn "t10 Correct: 0\t\tActual: %s" (exprToString (simplify t10))
printfn "t11 Correct: 0\t\tActual: %s" (exprToString (simplify t11))
printfn "t12 Correct: 0\t\tActual: %s" (exprToString (simplify t12))
printfn "t13 Correct: x\t\tActual: %s" (exprToString (simplify t13))
printfn "t14 Correct: y\t\tActual: %s" (exprToString (simplify t14))
printfn "t15 Correct: x\t\tActual: %s" (exprToString (simplify t15))
printfn "t16 Correct: 0\t\tActual: %s" (exprToString (simplify t16))
printfn "t17 Correct: 16\t\tActual: %s" (exprToString (simplify t17)) 
printfn "t18 Correct: -(y+3)\tActual: %s" (exprToString (simplify t18))
printfn "t19 Correct: x\t\tActual: %s" (exprToString (simplify t19))
printfn "t20 Correct: (x+2)*(-((2*y)-5))"
printfn "    Actual:  %s" (exprToString (simplify t20))

printfn "t21 Correct: 0\t\tActual: %s" (exprToString (simplify t21))
printfn "t22 Correct: 0\t\tActual: %s" (exprToString (simplify t22))
printfn "t23 Correct: 0\t\tActual: %s" (exprToString (simplify t23))
printfn "t24 Correct: 0\t\tActual: %s" (exprToString (simplify t24))
printfn "t25 Correct: 2*x\t\tActual: %s" (exprToString (simplify t25))
printfn "t26 Correct: 0\t\tActual: %s" (exprToString (simplify t26))
printfn "t27 Correct: x*x\t\tActual: %s" (exprToString (simplify t27))
printfn "t28 Correct: -x\t\tActual: %s" (exprToString (simplify t28))
printfn "t29 Correct: 2*y\t\tActual: %s" (exprToString (simplify t29))
printfn "t30 Correct: 0\t\tActual: %s" (exprToString (simplify t30))
printfn "t31 Correct: y*y\t\tActual: %s" (exprToString (simplify t31))
printfn "t32 Correct: -y\t\tActual: %s" (exprToString (simplify t32))
