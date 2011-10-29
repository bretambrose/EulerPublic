open System

(*
    This is a VS solution that contains my solutions to the problems in Project Euler.  I don't know how many I'll work through before stopping, but it seemed like a nice set
    of programming problems with which to learn F# and functional programming (which I haven't done since undergrad Programming Languages 16 years ago).  It's very hard
    to resist using imperative approaches and I know some/many/all of my solutions have serious inefficiencies in them.  Hopefully as I learn more about F#/functional prog
    these will disappear.

    For more on Project Euler, see www.projecteuler.net

    Note that in almost all cases I solved a more general problem, so that answering the specific question involves invoking a general function with a specific number.

    TODO: simple unit testing
    TODO: build parallelized solutions, alternate solutions for performance; test relative performance on multi-core machines
*)

let Test_All() =
    printfn "Testing NYI"
    ;;

let Answer_All() =
    printfn "Problem 1: %d" <| Problem1.Problem1_v1 999
    printfn "Problem 2: %d" <| Problem2.Problem2_v1 4000000
    printfn "Problem 3: %u" <| Problem3.Problem3_v1 600851475143UL
    printfn "Problem 4: %d" <| Problem4.Problem4_v1 3
    printfn "Problem 5: %u" <| Problem5.Problem5_v1 20UL
    printfn "Problem 6: %d" <| Problem6.Problem6_v1 100
    printfn "Problem 7: %d" <| Problem7.Problem7_v1 10001
    printfn "Problem 8: %d" <| Problem8.Problem8_v1 5
    printfn "Problem 9: %d" <| Problem9.Problem9_v1 1000
    printfn "Problem 10: %d" <| Problem10.Problem10_v1 2000000
    printfn "Problem 11: %d" <| Problem11.Problem11_v1 4
    printfn "Problem 12: %d" <| Problem12.Problem12_v1 500
    printfn "Problem 13: %d" <| Problem13.Problem13_v1()
    printfn "Problem 14: %d" <| Problem14.Problem14_v1 1000000
    printfn "Problem 15: %d" <| Problem15.Problem15_v1 20
    printfn "Problem 16: %A" <| Problem16.Problem16_v1 1000
    printfn "Problem 17: %d" <| Problem17.Problem17_v1()
    printfn "Problem 18: %d" <| Problem18.Problem18_v1()
    printfn "Problem 19: %d" <| Problem19.Problem19_v1 2000
    printfn "Problem 20: %A" <| Problem20.Problem20_v1 1000
    printfn "Problem 21: %d" <| Problem21.Problem21_v1 10000
    printfn "Problem 22: %d" <| Problem22.Problem22_v1()
    printfn "Problem 23: %d" <| Problem23.Problem23_v1()
    printfn "Problem 24: %A" <| Problem24.Problem24_v1 1000000
    printfn "Problem 25: %A" <| Problem25.Problem25_v1 1000
    printfn "Problem 26: %d" <| Problem26.Problem26_v1 1000
    printfn "Problem 27: %d" <| Problem27.Problem27_v1 1000
    printfn "Problem 28: %d" <| Problem28.Problem28_v1 500
    printfn "Problem 29: %d" <| Problem29.Problem29_v1 100
    printfn "Problem 30: %d" <| Problem30.Problem30_v1 5
   ;;

let Handle_Problem problem_number =
    match problem_number with
        | 1 -> Problem1.Problem1_v1_Interactive()
        | 2 -> Problem2.Problem2_v1_Interactive()
        | 3 -> Problem3.Problem3_v1_Interactive()
        | 4 -> Problem4.Problem4_v1_Interactive()
        | 5 -> Problem5.Problem5_v1_Interactive()
        | 6 -> Problem6.Problem6_v1_Interactive()
        | 7 -> Problem7.Problem7_v1_Interactive()
        | 8 -> Problem8.Problem8_v1_Interactive()
        | 9 -> Problem9.Problem9_v1_Interactive()
        | 10 -> Problem10.Problem10_v1_Interactive()
        | 11 -> Problem11.Problem11_v1_Interactive()
        | 12 -> Problem12.Problem12_v1_Interactive()
        | 13 -> Problem13.Problem13_v1_Interactive()
        | 14 -> Problem14.Problem14_v1_Interactive()
        | 15 -> Problem15.Problem15_v1_Interactive()
        | 16 -> Problem16.Problem16_v1_Interactive()
        | 17 -> Problem17.Problem17_v1_Interactive()
        | 18 -> Problem18.Problem18_v1_Interactive()
        | 19 -> Problem19.Problem19_v1_Interactive()
        | 20 -> Problem20.Problem20_v1_Interactive()
        | 21 -> Problem21.Problem21_v1_Interactive()
        | 22 -> Problem22.Problem22_v1_Interactive()
        | 23 -> Problem23.Problem23_v1_Interactive()
        | 24 -> Problem24.Problem24_v1_Interactive()
        | 25 -> Problem25.Problem25_v1_Interactive()
        | 26 -> Problem26.Problem26_v1_Interactive()
        | 27 -> Problem27.Problem27_v1_Interactive()
        | 28 -> Problem28.Problem28_v1_Interactive()
        | 29 -> Problem29.Problem29_v1_Interactive()
        | 30 -> Problem30.Problem30_v1_Interactive()
        | _ -> ();;


let Handle_Input_Directive input =
    match input with
        | "QUIT" -> 
            true
        | "ANSWERS" -> 
            Answer_All()
            false
        | "TEST" ->
            Test_All()
            false
        | number_string -> 
            let success, problem_number = Int32.TryParse number_string
            if success = true then
                Handle_Problem problem_number
            false

[<EntryPoint>]
let main (args : string[]) =
    printfn "Main Test"

    let mutable is_done = false
    while ( not is_done ) do
        printfn "Type a problem number to interact with a specific problem; type 'Answers' to see all answers; type 'test' to run unit tests; type 'quit' to quit"
        printfn ""

        let input_directive = Console.ReadLine()
        let upper_input = input_directive.ToUpper()
        is_done <- Handle_Input_Directive upper_input
 
    0

