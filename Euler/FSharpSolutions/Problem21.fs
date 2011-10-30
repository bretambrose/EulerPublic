(*
    Problem21.fs
        Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
        If d(a) = b and d(b) = a, where a != b, then a and b are an amicable pair and each of a and b are called amicable numbers.

        For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

        Evaluate the sum of all the amicable numbers under 10000.

        Solution Notes:

        I should get rid of both n and divisor_sum_array from the tail aux function by making it local and setting n to the array length

        One potential gotcha, you must check to see if a number refers to itself as the problem definition requires the pair of numbers to be different from one another.  There are
        several numbers (perfect) which fall into this category.

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

module Problem21

open System

let rec Amicable_Sum_Tail_Aux ( divisor_sum_array : int [] ) n current_number current_sum =
    if current_number >= n then
        current_sum
    else
        let current_divisor_sum = divisor_sum_array.[ current_number ]
        if current_divisor_sum < 2 || current_divisor_sum >= n || current_divisor_sum = current_number || divisor_sum_array.[ current_divisor_sum ] <> current_number then
            Amicable_Sum_Tail_Aux divisor_sum_array n ( current_number + 1 ) current_sum
        else
            Amicable_Sum_Tail_Aux divisor_sum_array n ( current_number + 1 ) ( current_sum + current_number );;

let Amicable_Sum_Tail divisor_sum_array n =
    Amicable_Sum_Tail_Aux divisor_sum_array n 2 0;;

let Problem21_v1 n =
    let divisor_sum_array = Array.init n (fun x -> 0)

    for current_number = 0 to n - 1 do
        divisor_sum_array.[ current_number ] <- UserNumerics.Divisor_Sum current_number

    Amicable_Sum_Tail divisor_sum_array n;;
    

let Problem21_v1_Interactive() =
    printfn "Problem 21: Evaluate the sum of all the amicable numbers under N, where N = 10000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem21_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;