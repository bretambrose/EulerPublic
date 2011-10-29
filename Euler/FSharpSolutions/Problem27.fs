module Problem27

open System

(*

    Euler published the remarkable quadratic formula:

    n² + n + 41

    It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 40^2 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, 
    and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.

    Using computers, the incredible formula  n² - 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. 
    The product of the coefficients, -79 and 1601, is -126479.

    Considering quadratics of the form:

    n² + an + b, where |a| < 1000 and |b| < 1000

    where |n| is the modulus/absolute value of n
    e.g. |11| = 11 and |-4| = 4
    Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.

    Solution Notes:

    I'm going to start off assuming b must be positive (since otherwise for n = 0, the result would be negative) and a prime.   
    
    Ultimately, I test the space -1000 < a < 1000 and b in [ all primes < 1000 ].  There are some additional analyses you could do to cut down the search space on a ( you can throw
    away most even values of a, for example), but they complicate the initial sequence generation quite a bit and performance is fine as is.

    For very low |a|, b there are some intelligent cutoffs ( for example, you know that evaluating with n = b leads to a non-prime when a is positive and usually is non-prime when
    a is negative) but this isn't worth doing since we know the best prime generator is between 40 and 80 members long and thus this optimization is likely to only apply to a 
    small percentage of the (a,b) tuples we need to check.
*)

let Create_Quadratic_Generator a b =
    let QuadraticGenerator =
        let n = ref 0
        (fun() -> let output = !n * !n + a * !n + b in n := !n + 1; output )
    QuadraticGenerator;;

let Test_Quadratic_Equation a b =
    let generator = Create_Quadratic_Generator a b
    let rec Test_Generator prime_count =
        let value = generator()
        if Prime.Is_Prime2 value then
            Test_Generator prime_count + 1
        else
            prime_count

    Test_Generator 0;;

let Problem27_v1 n =
    let b_seq = Prime.Build_Sieve_Array n |> Array.toSeq
    seq { for a in { -n + 1 .. n - 1 } do 
            for b in b_seq -> ( a, b ) }
        |> Seq.map ( fun (a, b) -> ( a * b, Test_Quadratic_Equation a b ) )
        |> Seq.maxBy ( fun ( prod, length ) -> length )
        |> fst;;

let Problem27_v1_Interactive() =
    printfn "Problem 27: Find the product of the coefficients, a and b, st |a| < N and |b| < N, for the quadratic expression that produces the maximum number of primes, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem27_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;