module Problem25

open System

(*

    The Fibonacci sequence is defined by the recurrence relation:

    F(n) = F(n-1) + F(n-2), where F(1) = 1 and F(2) = 1.

    F(12) = 144
    The 12th term, F(12), is the first term to contain three digits.

    What is the first term in the Fibonacci sequence to contain 1000 digits?

    Solution Notes:

    To do something new, I used the generator pattern for sequences here.  I like it but it's kind of strange.  I also converted the fib logic to a genericized version.
*)

let Problem25_v1 n =
    if n < 1 then
        failwith "invalid value for n"

    let divisor = bigint.Pow (10I, n - 1)
    let generator = Fibonacci.CreateIndexedFibonacciGeneratorBigInt()
    let mutable fib_pair = generator()
    while (fst fib_pair) / divisor = 0I do
        fib_pair <- generator()

    snd fib_pair;;

let Problem25_v1_Interactive() =
    printfn "Problem 25: What is the first term in the Fibonacci sequence to contain N digits?, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem25_v1 N
        printfn "For N = %d, the answer is %A" N result_N
    ();;