(*
    Problem19.fs
        You are given the following information, but you may prefer to do some research for yourself.

            1 Jan 1900 was a Monday.

            Thirty days has September, April, June and November.
            All the rest have thirty-one,
            Saving February alone,
            Which has twenty-eight, rain or shine.
            And on leap years, twenty-nine.

            A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

        How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

        Solution Notes:
        
            I represented Sunday as 0, Monday as 1, ...., up to Saturday as 6

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

module Problem19

open System

// tail recursive function to build a set of partial sums of a list; used to convert the days per month list into
// an absolute list representing days into a year
let rec Partial_Sum_Aux l1 l2 =
    match l1 with
        | [] -> List.rev l2
        | h :: [] -> List.rev l2
        | h :: t -> Partial_Sum_Aux t ( ( h + List.head l2 ) :: l2 );;

let Month_Day_Partial_Sum l =
    Partial_Sum_Aux l [0];;

let Leap_Year_Bonus y =
    if ( y % 4 = 0 && ( y % 400 = 0 || y % 100 <> 0 ) ) then
        1
    else
        0;;

// computes the starting day ( 0 .. 6 ) for each year in a list of years.  Because each year needs the answer from the previous year before it starts, I can't use map.
// Not tail recursive
let rec Build_Starting_Day_List year_list starting_day =
    match year_list with
        | h :: t -> starting_day :: Build_Starting_Day_List t ( ( starting_day + 365 + Leap_Year_Bonus h ) % 7 )
        | [] -> [];;

// given the day-month counts for both a leap year and a normal year, counts the number of first Sundays for a given year, starting_day pair
let Count_First_Sundays normal_fdom leap_fdom (year, starting_day) =
    if ( Leap_Year_Bonus year = 1 ) then
        leap_fdom
    else
        normal_fdom
    |> List.map (fun x -> ( x + starting_day ) % 7)
    |> List.map (fun x -> if x = 0 then 1 else 0)
    |> List.sum;;

let Problem19_v1 n =
    let days_per_month_normal = [ 31; 28; 31; 30; 31; 30; 31; 31; 30; 31; 30; 31 ]
    let days_per_month_leap = [ 31; 29; 31; 30; 31; 30; 31; 31; 30; 31; 30; 31 ]
    let first_day_of_months_normal = days_per_month_normal |> Month_Day_Partial_Sum
    let first_day_of_months_leap = days_per_month_leap |> Month_Day_Partial_Sum

    let year_list = [1901 .. n]
    let starting_day_1900 = 1   
    let starting_day_1901 = ( starting_day_1900 + 365 + Leap_Year_Bonus 1900 ) % 7

    let starting_day_list = Build_Starting_Day_List year_list starting_day_1901

    List.zip year_list starting_day_list
        |> List.map (Count_First_Sundays first_day_of_months_normal first_day_of_months_leap)
        |> List.sum;;

let Problem19_v1_Interactive() =
    printfn "Problem 19: How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?"
    printfn "Input alternate ending year:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem19_v1 N
        printfn "The answer is %d" result_N
    ();;