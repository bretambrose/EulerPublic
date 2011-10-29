module Problem4

open System

(*

A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99.

Find the largest palindrome made from the product of two 3-digit numbers

Notes:

I was sorely tempted to convert the products to strings and do the palindrom test on the string rather than a number.  Testing palindromes on numbers
involves an unpleasant amount of dividing and modding as well as using exponentiation if you don't precompute a vector of base ^ n values to divide against (which
I didn't). 
*)
let Is_Palindrome_Base_10 x =
    UserNumerics.Is_Palindrome x 10;;

let Problem4_v1 n =
    let range_min = pown 10 (n - 1)
    let range_max = (pown 10 n ) - 1

    let product_sequence = seq {
        for prod1 in range_min .. range_max do
            for prod2 in prod1 .. range_max do
                yield prod1 * prod2
    }

    let palindrome_sequence = Seq.filter Is_Palindrome_Base_10 product_sequence
    Seq.max palindrome_sequence;;

let Problem4_v1_Interactive() =
    printfn "Problem4: Find the largest palindrome made from the product of two N-digit numbers, where N = 3."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem4_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;
