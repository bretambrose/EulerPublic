﻿(*
    Problem29.fs
        Consider all integer combinations of a^b for 2 <= a <= 5 and 2 <= b <= 5:

        2^2=4, 2^3=8, 2^4=16, 2^5=32
        3^2=9, 3^3=27, 3^4=81, 3^5=243
        4^2=16, 4^3=64, 4^4=256, 4^5=1024
        5^2=25, 5^3=125, 5^4=625, 5^5=3125
        If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:

        4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125

        How many distinct terms are in the sequence generated by a^b for 2 <= a <= 100 and 2 <= b <= 100?

        Solution Notes:

        I used HashSet for uniqueness resolution

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

module Problem29

open System
open System.Collections.Generic

let Problem29_v1 N : int =
    let set = new HashSet< bigint >( seq { for i in 2 .. N do
                                                for j in 2 .. N -> bigint.Pow ( bigint i, j ) } )
    set.Count;;

let Problem29_v1_Interactive() =
    printfn "Problem 29:  How many distinct terms are in the sequence generated by a^b for 2 <= a <= N and 2 <= b <= N, where N = 100."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem29_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;