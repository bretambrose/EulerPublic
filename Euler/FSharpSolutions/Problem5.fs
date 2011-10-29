module Problem5

open System

(*
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

Notes: I ended up constructing a LCM(set) type of function that uses the prime decomposition of each
 of the numbers 1 to 20 to construct the factorization of a number that, when rebuilt from its
 factorization, is the answer
*)

let Count_Factors prime n =
    let reduction, occurrence_count = Prime.Compute_Prime_Factor n prime
    int occurrence_count;;

let Prime_Factor_List_Mapper numeric_list prime =
    let occurrences_list = List.map (Count_Factors prime) numeric_list
    (prime, List.max occurrences_list);;

let Fold_LCM_From_Factors_List current_product (prime, factors ) =
    current_product * (pown prime factors);;

let Problem5_v1 n =
    if n <= 2UL then
        n
    else
        let prime_list = Prime.Build_Prime_List n
        let numeric_list = [ 2UL..n ]

        prime_list |>
            List.map (Prime_Factor_List_Mapper numeric_list) |>
            List.fold Fold_LCM_From_Factors_List 1UL;;

let Problem5_v1_Interactive() =
    printfn "Problem 5: What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20, where N = 20."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = UInt64.TryParse N_string
    if success = true then
        let result_N = Problem5_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;