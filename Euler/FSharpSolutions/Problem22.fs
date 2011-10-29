module Problem22

open System
open System.IO
open System.Text.RegularExpressions

(*

    Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
    Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

    For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
    So, COLIN would obtain a score of 938  53 = 49714.

    What is the total of all the name scores in the file?

    Solution Notes:

    Not a very interesting problem.  
*)

let Build_Name_List ( file : StreamReader ) =
    let name_string = file.ReadLine()
    let line_regex = new Regex( @"["",\s]+" )
    line_regex.Split( name_string )
        |> Array.toList;;

let Compute_Name_Score ( name : string ) =
    let mutable sum = 0
    let a_as_int = int 'A'
    for letter in name do
        let letter_as_int = int letter
        sum <- sum + letter_as_int - a_as_int + 1

    sum;;

let rec Sum_Name_Scores_Aux names index current_score =
    match names with
        | h :: t -> Sum_Name_Scores_Aux t ( index + 1 ) ( current_score + int64 ( index * Compute_Name_Score h ) )
        | [] ->  current_score;;

let Sum_Name_Scores l =
    Sum_Name_Scores_Aux l 1 0L;;

let Problem22_v1() =
    let name_list = 
        File.OpenText "Data//Problem22.txt"
            |> Build_Name_List

    let filtered_list = List.filter ( fun ( x : string ) -> x.Length > 0 ) name_list    // unfortunate

    let name_array = List.toArray filtered_list
    let sorted_array = Array.sort name_array
    let sorted_list = Array.toList sorted_array

    Sum_Name_Scores sorted_list;;

let Problem22_v1_Interactive() =
    printfn "Problem 22: What is the total of all the name scores in the file?  "
    printfn "I have not included a parameterization of this problem."
    let result = Problem22_v1()
    printfn "The answer is %d" result
    ();;