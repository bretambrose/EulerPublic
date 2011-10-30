(*
    Problem6.fs
        The sum of the squares of the first ten natural numbers is,

        1^2 + 2^2 + ... + 10^2 = 385

        The square of the sum of the first ten natural numbers is,

        (1 + 2 + ... + 10)^2 = 552 = 3025

        Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.

        Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

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

module Problem6

open System

let Problem6_v1 n =
    let n_seq = seq { 1..n }
    let n_seq_sum = Seq.fold (+) 0 n_seq
    let square_of_sums = n_seq_sum * n_seq_sum

    let squares_seq = Seq.map (fun x -> x * x) n_seq
    let sum_of_squares =  Seq.fold (+) 0 squares_seq
    square_of_sums - sum_of_squares;;

let Problem6_v1_Interactive() =
    printfn "Problem 6: Find the difference between the sum of the squares of the first N natural numbers and the square of the sum, where N = 100."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem6_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;