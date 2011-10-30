(*
    Problem20.fs
        n! means n * (n - 1) * ...  3 * 2 * 1

        Find the sum of the digits in the number 100!

        Solution Notes:

        Maybe there's a smart way of doing this, but I just used bigint.  I should genericize factorial.

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

module Problem20

open System

let Problem20_v1 ( n : int ) =
    let power = UserNumerics.Factorial_I ( bigint n )
    UserNumerics.Count_Digits_I power 10I 0I;;

let Problem20_v1_Interactive() =
    printfn "Problem1: What is the sum of the digits of N!, where N = 1000."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem20_v1 N
        printfn "For N = %d, the answer is %A" N result_N
    ();;
