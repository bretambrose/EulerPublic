module Fibonacci

(*
    Originally inspired by the Fibonacci generator on page ?? of Programming F#.

    This version adds a controllable limit (n) to the process.  It also only lists 1 once because that was what was needed by the Euler problem.  Additional versions
    have the additional 1.
*)
let Fibonacci_Generator_By_Max (n, a, b) =
    if b > n then
        None
    else
        Some( b, (n, b, a + b ));;

let Generate_Fibonacci_Seq_Up_To n =
    Seq.unfold Fibonacci_Generator_By_Max (n, 1, 1);;

let GenericCreateFibonacciGenerator ( one, sum ) =
    let FibonacciGenerator =
        let current_pair = ref (one, one)
        (fun() -> let output = fst !current_pair in current_pair := ( snd !current_pair, sum ( fst !current_pair ) ( snd !current_pair ) ); output )
    FibonacciGenerator;;

let CreateFibonacciGeneratorInt32() =
    GenericCreateFibonacciGenerator (1, (+));;

let CreateFibonacciGeneratorBigInt() =
    GenericCreateFibonacciGenerator (1I, (+));;

let GenericCreateIndexedFibonacciGenerator ( one, sum ) =
    let FibonacciGenerator =
        let current_pair = ref (one, one)
        let current_index = ref 1
        (fun() -> let output = ( fst !current_pair, !current_index ) in current_pair := ( snd !current_pair, sum ( fst !current_pair ) ( snd !current_pair ) ); current_index := !current_index + 1; output )
    FibonacciGenerator;;

let CreateIndexedFibonacciGeneratorInt32() =
    GenericCreateIndexedFibonacciGenerator (1, (+));;

let CreateIndexedFibonacciGeneratorBigInt() =
    GenericCreateIndexedFibonacciGenerator (1I, (+));;