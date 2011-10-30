(*
    Problem9.fs
       A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

        a^2 + b^2 = c^2
        For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

        There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        Find the product a * b * c.

        Solution Notes: 
    
        The most naive approach iterates through approximately N^2 tuples checking each result.
        A more detailed analysis of the basic equations yields a much better solution.  In particular,
        a smarter approach checks only O(N) tuples (in fact, for N = 1000, it ends up being around 200 possibilities to check)

        Let's determine min and max bounds for b first.

        We know:

            a + b + c = N

            a^2 + b^2 = c^2

            a < b < c

        From this we can immediately see that

            c >= N / 3

        First the bounds for b:

            b >= sqrt( N^2 - 9 ) / 3
            b < ( N + 1 ) / 2

        The maximum bound is trivial based on the fact that b < c.
        The minimum bound works as follows:
            b^2 = c^2 - a^2
            b^2 >= (N/3)^2 - a^2
            b^2 >= (N/3)^2 - 1
            b >= Sqrt( ( N^2 - 9 ) / 9 )
            b >= Sqrt( N^2 - 9 ) / 3

        Now for fixed b, let's figure out min and max bounds for a.  With these in hand we'll be able to build a minimal sequence
        that iterates over candidate values for a and b (with c implicit).

        Given c >= N / 3, we can immediately conclude
            a + b <= 2N / 3

        So an immediate upper bound for a in terms of N and b is

            a <= 2N / 3  - b

        [here I took a bath and thought about the problem some more]

        Remarkably, it turns out that rather than a range for a, once we fix b, there is a single value of a to check; if it fails (to be integral)
        then no other other tuple for that b is possible.

        In particular, here is a proof by appeal-to-intuition (hah)

        For a fixed b and N, consider the quantities

            a^2 + b^2

        and

            c^2 = ( N - a - b )^2

        Let a range from b-1 down to 1, notice that as this iteration proceeds, a^2 + b^2 is a *STRICTLY* decreasing quantity
        and c^2 = ( N - a - b )^2 is a *STRICTLY* increasing quantity.  Given those two facts, there can only be one possible
        value of a where the two quantities are equal.

        I leave solving for a in terms of b and N an exercise for the reader since writing out the algebra in a program comment is a pain.

        But the basic approach is to start with

            a^2 + b^2 = c^2

        substitute 
        
            c = N - a - b

        and then solve for a.

        The final equation yields:

            a = ( N * ( 2b - N ) ) / ( 2 * ( b - n ) )

        Try subbing in N = 12, b = 4 and you'll get a = 3 as you'd expect

        So our final approach is the following:
            Iterate b according to the min and max bounds we figured above
            Compute the numerator and denominator of the fractional equation for a.  If a is an integer, then we have a pythagorean triple.

        Our more general solver builds a list of all Pythagorean triples for a given N.  To solve the Project Euler problem we generate this list for N = 1000,
        and having only one element, compute a * b * c from the one triplet in the list.

        Post-solution notes:

        Reading the problem's forum thread, I was surprise to discover that for N = 1000, you can solve for a and b directly.  That approach does not extend to general N,
        unfortunately.  N = 1200, for example, has 5 distinct Pythagorean triplets.  Meanwhile, N = 1001 has zero Pythagorean triplets.

	(c) Copyright 2011, Bret Ambrose (mailto:bretambrose@gmail.com).

	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
 
*)

module Problem9

open System

let Concat_List accum_list new_list =
    List.append accum_list new_list;;

let Pythagorean_Triple_Of_B_And_N n b =
    if b >= n || b < 2 then
        []
    else
        let a_numerator = n * ( 2 * b - n )
        let a_denominator = 2 * ( b - n )
        if a_numerator % a_denominator <> 0 then
            []
        else
            let a = a_numerator / a_denominator
            if a >= b || a < 1 then
                []
            else
                [( a, b, n - a - b )]

let Pythagorean_Triple_List_Generator n =
    let b_min = int ( sqrt ( double ( n * n - 9 ) ) / 3.0 )
    let b_max = ( n + 1 ) / 2

    seq { b_min .. b_max }
        |> Seq.map ( Pythagorean_Triple_Of_B_And_N n )
        |> Seq.fold Concat_List [];;

let Problem9_v1 n =
    let triple_list = Pythagorean_Triple_List_Generator n
    let a, b, c = List.head triple_list
    a * b * c;;

let Problem9_v1_Interactive() =
    printfn "Problem 9: Find the product of the Pythagorean triple such that a + b + c = N, where N = 1000."
    printfn "For alternate N, we compute the set of triples, since they may not exist or may not be unique."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Pythagorean_Triple_List_Generator N
        printfn "For N = %d, the set of Pythagorean triplets is %A" N result_N
    ();;

