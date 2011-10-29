module Problem24

open System
open System.Collections.Generic
open System.Collections

(*

    A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
    If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

    012   021   102   120   201   210

    What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

    Solution Notes:

    While mathematically easy, I struggled with the data representation again, and eventually gave up and used an array.  The smart solution requires
    an iterative resorting of the remaining indices (unless you swap and shift directly, but that requires writing extra code) and anything other than
    an array is not good for that.  I looked into .NET's sorted data structures and none of them had indexed random access (keyed random access will not
    work unless you reassign keys every iteration).

    The basic idea of the solution is to compute each digit, from left-to-right, by dividing an accumulation variable (which starts at n = 1000000) by the
    number of possible ordering of the remaining digits (k!, where k is the number of remaining digits).  The accumulation variable becomes the remainder of 
    that division and the digit set is reduced and resorted (because we exchanged the correct digit with whatever was in the current index).
*)

let Compute_Digit_Permutation n =
    let sorted_digits = Array.init 10 ( fun i -> i )

    let rec Compute_Digit_Permutation_Aux remaining_n current_index =
        match current_index with
            | _ when current_index >= 9 -> ()   // we're done
            | _ ->
                let remaining_factorial = UserNumerics.Factorial ( 9 - current_index )  
                let next_digit_index = remaining_n / remaining_factorial + current_index

                // compute the right digit and do a swap
                let next_digit = sorted_digits.[ next_digit_index ] 
                let temp_digit = sorted_digits.[ current_index ]
                sorted_digits.[ next_digit_index ] <- temp_digit
                sorted_digits.[ current_index ] <- next_digit

                // resort the remaining digits
                Array.Sort (sorted_digits, ( current_index + 1 ), ( 10 - ( current_index + 1 ) ) )
                Compute_Digit_Permutation_Aux ( remaining_n % remaining_factorial ) ( current_index + 1 )


    Compute_Digit_Permutation_Aux n 0
    sorted_digits;;

let Problem24_v1 n =
    let ten_factorial = UserNumerics.Factorial 10
    if n < 1 || n > ten_factorial then
        []
    else
        Array.toList ( Compute_Digit_Permutation (n - 1) );;
    

let Problem24_v1_Interactive() =
    printfn "Problem 24: What is the Nth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9, where N = 1000000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem24_v1 N
        printfn "For N = %d, the answer is %A" N result_N
    ();;