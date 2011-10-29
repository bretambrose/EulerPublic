module Problem23

open System

(*

    A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
    For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

    A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

    As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
    By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
    However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed 
    as the sum of two abundant numbers is less than this limit.

    Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

    Solution Notes:

    Rather than work backwards from numbers, I just generate all pairwise sums from an abundant number list and mark an array, sieve-style.
    The numbers in the identity-initialized array that remain cannot be written as sums and so you can simple sum the array.
*)

let Problem23_v1() =
    let abundant_test_max = 28123
    let abundant_list = 
        [1 .. abundant_test_max]
            |> List.filter ( fun n -> UserNumerics.Divisor_Sum n > n )

    let abundant_sum_sieve = Array.init ( abundant_test_max + 1 ) ( fun n -> n )    // hmm I could also just do [| 0 .. abundant_test_max |]

    let rec mark_abundant_sums a_list =
        match a_list with
            | [] -> ()
            | h :: t ->
                ( h :: t ) 
                    |> List.map ( fun n -> n + h )
                    |> List.iter ( fun n -> if n <= abundant_test_max then abundant_sum_sieve.[ n ] <- 0 else () )
                mark_abundant_sums t

    mark_abundant_sums abundant_list
    abundant_sum_sieve |> Array.sum;;

let Problem23_v1_Interactive() =
    printfn "Problem 23: Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers"
    printfn "I have not included a parameterization of this problem."
    let result = Problem23_v1()
    printfn "The answer is %d" result
    ();;