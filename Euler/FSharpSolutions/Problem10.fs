module Problem10

open System

(*
    Find the sum of all the primes below two million.

    Solution notes: Sieve of Erastothenes is ideal here, although it's memory footprint is rough
*)

(*
    Our sieve will have zero meaning something's not a prime and the index itself meaning something is a prime
    Once we have a correct array, we can just sum it to get the final answer
*)

let Sum_Array_UInt64 ( current_sum : uint64 ) new_term =
    uint64 new_term + current_sum;;

let Problem10_v1 n =
    let sieve_array = Array.init n ( fun x -> x )

    // mark 1 as not prime
    sieve_array.[ 1 ] <- 0

    let max_sieve_index = n / 2
    for base_factor = 2 to max_sieve_index do
        if sieve_array.[ base_factor ] <> 0 then
            let mutable index = base_factor * 2
            while index < n do
                sieve_array.[ index ] <- 0
                index <- index + base_factor

    Array.fold Sum_Array_UInt64 0UL sieve_array;;
    

let Problem10_v1_Interactive() =
    printfn "Problem 10: Find the sum of all the primes below N, where N = 2000000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem10_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;

