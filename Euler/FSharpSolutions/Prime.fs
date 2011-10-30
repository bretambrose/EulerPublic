(*

    Prime.fs
        Prime number related functions

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

module Prime

// computes how many times n goes into x, as well as what remains after that division has been done
let rec Compute_Prime_Factor x n =
    if x <= 1UL || x % n <> 0UL then
        (x, 0UL)
    else
        let f_x, factors = Compute_Prime_Factor (x/n) n
        (f_x, 1UL + factors);;

// Assumes you're factoring the number (the limit is sqrt-based) rather than using sieve over a range (where the limit is x/2)
// If the sqrt is an even number that's not 2, then use the next lowest odd number
let Compute_Highest_Divisor ( x : uint64 ) =
    let divisor = uint64 (sqrt (double x ) )
    if divisor <= 2UL || divisor % 2UL = 1UL then
        divisor
    else
        divisor - 1UL;;

let Construct_Divisor_Sequence n =
    if n < 2UL then
        Seq.empty
    else
        seq { 2UL .. n } |> Seq.filter (fun x -> x % 2UL = 1UL || x = 2UL);;

let Factor_Sequence_Folder (x, factor_list) n =
    let new_x, factors = Compute_Prime_Factor x n
    if factors > 0UL then
        ( new_x, List.Cons ( (n, factors) , factor_list ) )
    else
        ( x, factor_list );;

let Build_Factor_List2 x divisor_sequence =
    Seq.fold Factor_Sequence_Folder (x, []) divisor_sequence;;

let Factor_Aux x =
    match x with
    | _ when x < 1UL -> []
    | _ -> snd <| Build_Factor_List2 x ( Construct_Divisor_Sequence ( Compute_Highest_Divisor x ) );;

let Factor x =
    let factor_list = Factor_Aux x
    if List.length factor_list = 0 then
        [ ( x, 1UL ) ]
    else
        factor_list;;

let Evenly_Divides_Folder x still_prime n =
    still_prime && ( x % n <> 0UL );;

let Is_Prime x =
    if x <= 1UL then
        false
    else
        let div_sequence = Construct_Divisor_Sequence ( Compute_Highest_Divisor x )
        Seq.fold (Evenly_Divides_Folder x) true div_sequence;;

let Is_Prime2 x = 
    if x < 2 || x % 2 = 0 then
        false
    else
        let max_factor = int ( sqrt ( float x ) )
        let rec Test_X divisor =
            if divisor > max_factor then
                true
            else if x % divisor = 0 then
                false
            else
                Test_X ( divisor + 2 )

        Test_X 3;;

let Build_Prime_List n =
    if n <= 1UL then
        []
    else
        let div_sequence = Construct_Divisor_Sequence n
        div_sequence |> Seq.filter Is_Prime |> Seq.toList;;

let Build_Sieve_Array n =
    let sieve_array = Array.init n ( fun x -> x )

    // mark 1 as not prime
    sieve_array.[ 1 ] <- 0

    let max_sieve_index = n / 2
    for base_factor = 2 to max_sieve_index do
        if sieve_array.[ base_factor ] <> 0 then
            let mutable index = base_factor * 2
            while index < n do
                sieve_array.[ index ] <- 0
                index <- index + base_factor

    sieve_array
        |> Array.filter ( fun i -> i <> 0 );;
       