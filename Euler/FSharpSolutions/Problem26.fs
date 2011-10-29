module Problem26

open System

(*

    A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

    1/2	= 	0.5
    1/3	= 	0.(3)
    1/4	= 	0.25
    1/5	= 	0.2
    1/6	= 	0.1(6)
    1/7	= 	0.(142857)
    1/8	= 	0.125
    1/9	= 	0.(1)
    1/10	= 	0.1
    Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

    Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

    Solution Notes:

    When dividing a number into another, a cycle occurs once you've seen the same remainder twice.  So my solution simply creates a zero-filled array
    with one entry per possible remainder (mod N).  When you see a remainder for the first time (the array element is zero) you record how many digits
    you've generated and put it into the array element.  When you see a remainder for the second time (the array element is non-zero) then you subtract
    how many digits you've generated from the value in the array element to get the cycle length.

*)

let Compute_Recurring_Cycle_Length n =
    let remainder_indices = Array.create n 0
    let rec Cycle_Length_Aux current_val current_index =
        let remainder = current_val % n
        if remainder_indices.[ remainder ] <> 0 then
            current_index - remainder_indices.[ remainder ]
        else
            remainder_indices.[ remainder ] <- current_index
            Cycle_Length_Aux ( remainder * 10 ) ( current_index + 1 )

    Cycle_Length_Aux 1 1;;

let Problem26_v1 n =
    [ 2 .. ( n - 1 ) ]
        |> List.map ( fun i -> ( i, Compute_Recurring_Cycle_Length i ) )
        |> List.maxBy ( fun i -> snd i )
        |> fst;;

let Problem26_v1_Interactive() =
    printfn "Problem 26: Find the value of d < N for which 1/d contains the longest recurring cycle in its decimal fraction part, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem26_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;