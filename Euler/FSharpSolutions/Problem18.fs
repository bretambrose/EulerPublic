(*
    Problem18.fs
        By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

        3
        7 4
        2 4 6
        8 5 9 3

        That is, 3 + 7 + 4 + 9 = 23.

        Find the maximum total from top to bottom of the triangle below:

        75
        95 64
        17 47 82
        18 35 87 10
        20 04 82 47 65
        19 01 23 75 03 34
        88 02 77 73 07 63 67
        99 65 04 28 06 16 70 92
        41 41 26 56 83 40 80 70 33
        41 48 72 33 47 32 37 16 94 29
        53 71 44 65 25 43 91 52 97 51 14
        70 11 33 28 77 73 17 78 39 68 17 57
        91 71 52 38 17 14 91 43 58 50 27 29 48
        63 66 04 68 89 53 67 30 73 16 69 87 40 31
        04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

        NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle 
        containing one-hundred rows; it cannot be solved by brute force, and requires a clever method!

        Solution Notes:

        While this is a simple dynamic programming problem, I struggled quite a bit to figure out an underlying data representation that didn't involve a 2d array.
        In the end I used a list of lists, but that felt clunky and unsatisfying.

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

module Problem18

open System
open System.IO
open System.Text.RegularExpressions

// there's probably a library function that does this: sums the individual elements of two lists together in parallel
let rec Pairwise_Combine l1 l2 =
    match (l1, l2) with
        | (h1 :: t1, h2 :: t2) -> (h1 + h2) :: Pairwise_Combine t1 t2
        | _ -> [];;


// build a 1-smaller list that is the pairwise max of the elements of the input list
let rec Pairwise_Max l =
    match l with
        | x :: ( y :: z as t ) -> ( max x y ) :: Pairwise_Max t
        | _ -> [];;

// takes a line of integers as a single string and returns a list of ints
let Line_To_Int_List( line : string ) =
    let line_regex = new Regex( @"\s+" )
    line_regex.Split( line )
        |> Array.map ( fun x -> Int32.Parse( x ) )
        |> Array.toList;;

let rec Build_Triangle ( file : StreamReader ) =
    let number_string = file.ReadLine()
    if number_string = null || number_string.Length = 0 then
        []
    else
        Line_To_Int_List number_string :: Build_Triangle file;;

// walks through the list of lists, from the bottom row to the top (because we reversed the list of lists earlier), combining rows into an accumulation list.
let rec Reduce_Triangle remaining_triangle accum_row =
    match remaining_triangle with
        | [] -> List.head accum_row
        | h :: t -> 
            Pairwise_Max accum_row
                |> Pairwise_Combine h
                |> Reduce_Triangle t;;

let Problem18_v1() =
    let triangle_list = 
        File.OpenText "Data//Problem18.txt"
            |> Build_Triangle
            |> List.rev

    Reduce_Triangle (List.tail triangle_list) (List.head triangle_list);;

let Problem18_v1_Interactive() =
    printfn "Problem 18: Find the maximum total sum of traversing a number triangle as specified in Problem18.txt"
    printfn "I have not included a parameterization of this problem."
    let result = Problem18_v1()
    printfn "The answer is %d" result
    ();;