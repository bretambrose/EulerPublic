(*
    Problem43.fs
        The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting 
        sub-string divisibility property.

        Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

        d2 d3 d4 = 406 is divisible by 2
        d3 d4 d5 = 063 is divisible by 3
        d4 d5 d6 = 635 is divisible by 5
        d5 d6 d7 = 357 is divisible by 7
        d6 d7 d8 = 572 is divisible by 11
        d7 d8 d9 = 728 is divisible by 13
        d8 d9 d10 = 289 is divisible by 17

        Find the sum of all 0 to 9 pandigital numbers with this property.

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

module Problem43

open System
