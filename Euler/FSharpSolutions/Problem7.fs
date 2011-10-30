(*
    Problem7.fs
        By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

        What is the 10001st prime number?

        Notes: there are much, much more efficient ways of doing this, but this took 30 seconds to write given what I'd already done for previous problems.

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

module Problem7

open System

let Problem7_v1 n =
    Seq.initInfinite (fun x -> uint64 x) |>
        Seq.filter Prime.Is_Prime |>
        Seq.nth (n - 1);;

let Problem7_v1_Interactive() =
    printfn "Problem 7: Find the Nth prime number, where N = 10001."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem7_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;

