﻿(*

    Problem2.fs
        Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

        1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

        Find the sum of all the even-valued terms in the sequence which do not exceed four million.

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

module Problem2

open System

let Problem2_v1 n =
    Fibonacci.Generate_Fibonacci_Seq_Up_To n
        |> Seq.filter (fun x -> x % 2 = 0) 
        |> Seq.fold (+) 0;;

let Problem2_v1_Interactive() =
    printfn "Problem2: Find the sum of all the even-valued terms in the Dibonacci Sequence which do not exceed N, where N = 4000000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem2_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;

