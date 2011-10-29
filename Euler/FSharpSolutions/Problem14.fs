module Problem14

open System

(*

The following iterative sequence is defined for the set of positive integers:

n -> n/2 (n is even)
n -> 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1

It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

*)

let Calculate_Next_Sequence_Value ( n : uint64 ) =
    if n % 2UL = 0UL then
        n / 2UL
    else
        3UL * n + 1UL;;

let rec Calculate_Sequence_Length ( seq_lengths : int[] ) i =
    if i < uint64 seq_lengths.Length && seq_lengths.[ int i ] <> 0 then
        seq_lengths.[ int i ]
    else
        let next_i = Calculate_Next_Sequence_Value i
        let seq_length = 1 + Calculate_Sequence_Length seq_lengths next_i
        if i < uint64 seq_lengths.Length then
            seq_lengths.[ int i ] <- seq_length
        seq_length;;

let Problem14_v1 n =
    let steps = Array.zeroCreate ( n * 10 )     // create a larger array than necessary in order to cache results
    steps.[ 1 ] <- 1
    for i = 2 to n - 1 do
        ignore <| Calculate_Sequence_Length steps ( uint64 i ) 

    let mutable longest_seq_number = 1;
    for i = 2 to n - 1 do
        if steps.[ i ] > steps.[ longest_seq_number ] then
            longest_seq_number <- i

    longest_seq_number;;

let Problem14_v1_Interactive() =
    printfn "Problem 14: Find the longest sequence using a starting number under N, where N = 1000000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem14_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;

