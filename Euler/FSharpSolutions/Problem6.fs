module Problem6

open System

(*
The sum of the squares of the first ten natural numbers is,

1^2 + 2^2 + ... + 10^2 = 385

The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)^2 = 552 = 3025

Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
*)

let Problem6_v1 n =
    let n_seq = seq { 1..n }
    let n_seq_sum = Seq.fold (+) 0 n_seq
    let square_of_sums = n_seq_sum * n_seq_sum

    let squares_seq = Seq.map (fun x -> x * x) n_seq
    let sum_of_squares =  Seq.fold (+) 0 squares_seq
    square_of_sums - sum_of_squares;;

let Problem6_v1_Interactive() =
    printfn "Problem 6: Find the difference between the sum of the squares of the first N natural numbers and the square of the sum, where N = 100."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem6_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;