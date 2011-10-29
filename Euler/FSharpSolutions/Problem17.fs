module Problem17

open System

(*

    If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

    If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

    NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
    The use of "and" when writing out numbers is in compliance with British usage.

    Solution Notes:

    I got stuck on this for a bit because I added in the length of "one thousand" rather than "one" + "thousand" at the end.  Doh.  Also, Petra pointed out
    that 40 is not spelled "fourty".  
*)

let rec String_List_Length l current_sum =
    match l with
        | h :: t -> String_List_Length t (current_sum + String.length h)
        | [] -> current_sum;;
         
let Problem17_v1() =
    let one_to_nine_list = [ "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" ]
    let one_to_nine_sum = String_List_Length one_to_nine_list 0
    let ten_to_nineteen_list = [ "ten"; "eleven"; "twelve"; "thirteen"; "fourteen"; "fifteen"; "sixteen"; "seventeen"; "eighteen"; "nineteen" ]
    let ten_to_nineteen_sum = String_List_Length ten_to_nineteen_list 0
    let twenty_to_ninety_list = [ "twenty"; "thirty"; "forty"; "fifty"; "sixty"; "seventy"; "eighty"; "ninety" ]
    let twenty_to_ninety_sum = String_List_Length twenty_to_ninety_list 0
    let one_to_ninety_nine_sum = one_to_nine_sum + ten_to_nineteen_sum + 8 * one_to_nine_sum + 10 * twenty_to_ninety_sum
    let one_to_999_sum = 10 * one_to_ninety_nine_sum + 100 * one_to_nine_sum + 900 * ( String.length "hundred" ) + 9 * 99 * ( String.length "and" )
    one_to_999_sum + String.length "one" + String.length "thousand";;

let Problem17_v1_Interactive() =
    printfn "Problem 17: If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?"
    printfn "I have not included a parameterization of this problem."
    let result = Problem17_v1()
    printfn "The answer is %d" result
    ();;