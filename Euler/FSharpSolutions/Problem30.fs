module Problem30

open System

(*

    Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

    1634 = 1^4 + 6^4 + 3^4 + 4^4
    8208 = 8^4 + 2^4 + 0^4 + 8^4
    9474 = 9^4 + 4^4 + 7^4 + 4^4
    As 1 = 1^4 is not a sum it is not included.

    The sum of these numbers is 1634 + 8208 + 9474 = 19316.

    Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

    Solution Notes:

    The main thing we need to figure out is the maximum number we need to check.  Once we have that, then simple decompose everything in [2 .. MaxNumberToCheck]
    into single digits, sum the 5th powers of the digits, and check against the original number to test for membership, summing over the ones that pass to get
    the final answer.

*)

let rec Make_Digit_List value =
    if value < 10 then
        [ value ]
    else
        ( value % 10 ) :: Make_Digit_List ( value / 10 );;

let Problem30_v1 N =
    let max_to_check = ( N + 1 ) * int ( bigint.Pow ( 9I, N ) )
    let power_array = Array.init 10 ( fun i -> int ( bigint.Pow ( bigint i, N ) ) ) 

    let Is_Power_Sum value =
        let digit_sum = Make_Digit_List value
                            |> List.map ( fun i -> power_array.[ i ] )
                            |> List.sum
        digit_sum = value

    let number_list = Seq.toList ( seq { for i in 2 .. max_to_check do
                                            if Is_Power_Sum i then 
                                                yield i } )
    Seq.sum number_list;;

let Problem30_v1_Interactive() =
    printfn "Problem 30:  Find the sum of all the numbers that can be written as the sum of Nth powers of their digits, where N = 5."
    printfn "Input alternate N (higher than 5 is not advised):"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem30_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;