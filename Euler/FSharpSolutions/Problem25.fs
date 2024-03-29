﻿(*
    Problem25.fs
        The Fibonacci sequence is defined by the recurrence relation:

        F(n) = F(n-1) + F(n-2), where F(1) = 1 and F(2) = 1.

        F(12) = 144
        The 12th term, F(12), is the first term to contain three digits.

        What is the first term in the Fibonacci sequence to contain 1000 digits?

        Solution Notes:

        To do something new, I used the generator pattern for sequences here.  I like it but it's kind of strange.  I also converted the fib logic to a genericized version.

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

module Problem25

open System

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