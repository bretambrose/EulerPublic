(*

    Problem3.fs
        The prime factors of 13195 are 5, 7, 13 and 29.

        What is the largest prime factor of the number 600851475143 ?

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

module Problem3

open System

let Max_Factor_List current_max (factor, occurrences) =
    if factor > current_max then
        factor
    else
        current_max;;

// Overkill, but I wanted to write a factoring function anyways, and this problem is certainly easy if we have one of those
let Problem3_v1 x =
    Prime.Factor x 
        |> List.fold Max_Factor_List 0UL;;

let Problem3_v1_Interactive() =
    printfn "Problem3: What is the largest prime factor of the number N, where N = 600851475143."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = UInt64.TryParse N_string
    if success = true then
        let result_N = Problem3_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;