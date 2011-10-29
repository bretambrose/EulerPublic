module Problem28

open System

(*

    Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

    21 22 23 24 25
    20  7  8  9 10
    19  6  1  2 11
    18  5  4  3 12
    17 16 15 14 13

    It can be verified that the sum of the numbers on the diagonals is 101.

    What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

    Solution Notes:

    Rather than working in terms of the length of the square sides, let's instead work with a sequence starting at 1 .. n, where,
    for a given value i  in the sequence, the associated square has sides of length ( 2i + 1 ).  We skip the 1x1 square because
    we only want it to count once, not four times, when we do the final summing.

    A bunch of algebra that I'm not going to repeat here leads to the following formula for the lower-right diagonal:
        lr(i) = 4 * i^2 - 2 * i + 1

    Substituting values for i starting at 1 gives you { 3, 13, 31, etc... }

    Finally, we notice that the other diagonals are all functions of the lower right sequence.  In particular, the lower left
    sequence is the lower right sequence + 2i (i varying across the sequence).  The upper left is the same + 4i, and the upper
    right is the same + 6i.  We then sum all these sequences together algebraically to get
    the following final formula for the four corners of the square related to i:

        4 * ( 4 * i^2 + i + 1 )

    We then sum over this formula for i in [1 .. n] and add 1 to the final result.

    You can probably reduce this summation to a closed formula, but I'm not familiar with the summation formula for squares.

    Hmm, just googled it: n*(n+1)*(2n+1)/6

    which comes out to
        (n^2 + n)(2n + 1 )/6 =
        (2n^3 + 3n^2 + n)/6

    So we can split out our answer as
          16 * ( sum of squares 1 to n )
        + 4 * ( sum of 1 to n )     [ don't forget to divide by 2 like I did ]
        + 4 * n
        + 1

    This leads to version 2 of our solution which needs to be a 64 bit integer in order to avoid overflow due to the cubing.
*)

let Problem28_v1 n =
    1 + ( [ 1 .. n ]
            |> List.map ( fun i -> 4 * ( 4 * i * i + i + 1 ) )
            |> List.sum );;

let Problem28_v2 N =
    let n = int64 N
    let n_2 = n * n
    let n_3 = n_2 * n
    16L * ( 2L * n_3 + 3L * n_2 + n ) / 6L + 2L * ( n_2 + n ) + 4L * n + 1L;;

let Problem28_v1_Interactive() =
    printfn "Problem 28:  What is the sum of the numbers on the diagonals in a 2n+1 by 2n+1 spiral, where N = 500."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem28_v2 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;