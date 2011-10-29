module Problem20

open System

(*

    n! means n * (n - 1) * ...  3 * 2 * 1

    Find the sum of the digits in the number 100!

    Solution Notes:

    Maybe there's a smart way of doing this, but I just used bigint.  I should genericize factorial.
*)

let Problem20_v1 ( n : int ) =
    let power = UserNumerics.Factorial_I ( bigint n )
    UserNumerics.Count_Digits_I power 10I 0I;;

let Problem20_v1_Interactive() =
    printfn "Problem1: What is the sum of the digits of N!, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem20_v1 N
        printfn "For N = %d, the answer is %A" N result_N
    ();;
