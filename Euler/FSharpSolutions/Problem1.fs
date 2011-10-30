(*

    Problem1.fs
        If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

        Find the sum of all the multiples of 3 or 5 below 1000.

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

module Problem1

open System

let Is_Multiple_Of_3_Or_5 n =
    n % 3 = 0 || n % 5 = 0;;

// this function includes n in the list, therefor to solve the problem as specified you need to pass in 999
let Problem1_v1 n =
    [1 .. n] 
        |> List.filter Is_Multiple_Of_3_Or_5 
        |> List.reduce (+);;

let Problem1_v1_Interactive() =
    printfn "Problem1: Find the sum of all the multiples of 3 or 5 below N, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem1_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;