module Problem7

open System

(*
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10001st prime number?

Notes: there are much, much more efficient ways of doing this, but this took 30 seconds to write given what I'd already done for previous problems.
*)

let Problem7_v1 n =
    Seq.initInfinite (fun x -> uint64 x) |>
        Seq.filter Prime.Is_Prime |>
        Seq.nth (n - 1);;

let Problem7_v1_Interactive() =
    printfn "Problem 7: Find the Nth prime number, where N = 10001."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem7_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;

