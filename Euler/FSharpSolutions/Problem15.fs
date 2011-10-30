(*
    Problem15.fs
        How many routes are there through a 20 x 20 grid if no backtracking is allowed?

        Solution notes:

        Finally, a problem that's not completely lame.

        If you let R(m, n) denote how many unique routes exist in an m x n grid, then clearly

            R(1, i) = R(i, 1) = i + 1 
    
        for any i, giving us our base case.

        Similarly, it is easy to see

            R(i, j) = R(i-1, j) + R(i, j-1)

        for i, j > 1

        The solution translates these equations into a simple dynamic programming problem using a 2D array

        Post-solution notes:

        Hmm, you can actually calculate this directly using Choose(n, k), in particular Choose(2N, N).  In the more general
        case of an M x N grid, it becomes Choose( M + N, N ).  Guess I'm not so smart after all =(

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

module Problem15

open System

let Problem15_v1 n =
    let ( route_counts : uint64[,] ) = Array2D.zeroCreate (n + 1) (n + 1)
    for i = 1 to n do
        route_counts.[ 1, i ] <- uint64 i + 1UL
        route_counts.[ i, 1 ] <- uint64 i + 1UL

    for i = 2 to n do
        for j = 2 to i do
            let route_i_j = route_counts.[ ( i - 1 ), j ] + route_counts.[ i, ( j - 1 ) ]
            route_counts.[ i, j ] <- route_i_j
            route_counts.[ j, i ] <- route_i_j

    route_counts.[ n, n ];;

let Problem15_v1_Interactive() =
    printfn "Problem 15: How many routes are there through a N x N grid if no backtracking is allowed, where N = 20."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem15_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;
