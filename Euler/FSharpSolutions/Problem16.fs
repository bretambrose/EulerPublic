module Problem16

open System

(*

    2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

    What is the sum of the digits of the number 2^1000?

    Solution Notes:
    
    I tried looking at powers of two up to about 2^24 but couldn't see anything usable patternwise.  On the other hand, I did notice
    that powers of 3 always sum up to a multiple of 9, which was very odd.

    So bigint it is.

*)

let Problem16_v1 n =
    let power = bigint.Pow (2I, n)
    UserNumerics.Count_Digits_I power 10I 0I;;

let Problem16_v1_Interactive() =
    printfn "Problem1: What is the sum of the digits of 2^N, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem16_v1 N
        printfn "For N = %d, the answer is %A" N result_N
    ();;
