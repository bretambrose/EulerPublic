module UserNumerics

(*
    Miscellaneous numeric functions.  Stuff that doesn't belong in clear categories will probably all get lumped into here.
*)

// Palindrome helper functions
// These functions are shameful and I hate them
let rec Compute_Digit_Count n b =
    if n < b then
        1
    else
        1 + Compute_Digit_Count (n/b) b;;

let rec Get_Digit n b digit =
    let divisor = pown b (digit - 1)
    (n / divisor) % b;;

let rec Is_Palindrome_Aux n b digit_count digit =
    if digit > digit_count / 2 then
        true
    elif ( Get_Digit n b digit ) <> ( Get_Digit n b ( digit_count - digit + 1 ) ) then
        false
    else
        Is_Palindrome_Aux n b digit_count (digit + 1);;

let Is_Palindrome n b =
    Is_Palindrome_Aux n b (Compute_Digit_Count n b) 1;;
     
let rec Count_Digits_I (n : bigint) b current_sum =
    if n < b then
        current_sum + n
    else
        Count_Digits_I (n / b) b (current_sum + n % b);;

let Factorial n =
    let rec Factorial_Aux n accum =
        if n <= 1 then
            accum
        else
            Factorial_Aux ( n - 1 ) ( n * accum )

    Factorial_Aux n 1;;

let rec Factorial_Aux_I (n : bigint) accum =
    if ( n <= 1I ) then
        accum
    else
        Factorial_Aux_I (n - 1I) (n * accum);;

let Factorial_I (n : bigint ) =
    Factorial_Aux_I n 1I;;

                 
let Divisor_Sum n =

    let rec Divisor_Sum_Aux n max_factor current_divisor divisor_sum =
        match current_divisor with
            | _ when current_divisor > max_factor -> divisor_sum
            | _ when current_divisor = max_factor && max_factor * max_factor = n ->
                if n % max_factor = 0 then
                    divisor_sum + max_factor
                else
                    divisor_sum
            | _ ->
                if n % current_divisor = 0 then
                    Divisor_Sum_Aux n max_factor ( current_divisor + 1 ) ( divisor_sum + current_divisor + n / current_divisor )
                else
                    Divisor_Sum_Aux n max_factor ( current_divisor + 1 ) divisor_sum

    if n <= 1 then
        0
    else
        Divisor_Sum_Aux n ( int32 <| sqrt ( double n ) ) 2 1;;
