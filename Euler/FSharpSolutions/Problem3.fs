module Problem3

open System

(*
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
*)

let Max_Factor_List current_max (factor, occurrences) =
    if factor > current_max then
        factor
    else
        current_max;;

// Overkill, but I wanted to write a factoring function anyways, and this problem is certainly easy if we have one of those
let Problem3_v1 x =
    Prime.Factor x 
        |> List.fold Max_Factor_List 0UL;;

let Problem3_v1_Interactive() =
    printfn "Problem3: What is the largest prime factor of the number N, where N = 600851475143."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = UInt64.TryParse N_string
    if success = true then
        let result_N = Problem3_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;