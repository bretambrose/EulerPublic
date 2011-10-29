module Problem8

open System
open System.IO

(*
    Find the greatest product of five consecutive digits in the 1000-digit number:

    73167176531330624919225119674426574742355349194934
    96983520312774506326239578318016984801869478851843
    85861560789112949495459501737958331952853208805511
    12540698747158523863050715693290963295227443043557
    66896648950445244523161731856403098711121722383113
    62229893423380308135336276614282806444486645238749
    30358907296290491560440772390713810515859307960866
    70172427121883998797908792274921901699720888093776
    65727333001053367881220235421809751254540594752243
    52584907711670556013604839586446706324415722155397
    53697817977846174064955149290862569321978468622482
    83972241375657056057490261407972968652414535100474
    82166370484403199890008895243450658541227588666881
    16427171479924442928230863465674813919123162824586
    17866458359124566529476545682848912883142607690042
    24219022671055626321111109370544217506941658960408
    07198403850962455444362981230987879927244284909188
    84580156166097919133875499200524063689912560717606
    05886116467109405077541002256983155200055935729725
    71636269561882670428252483600823257530420752963450

    Imperative solution, but this problem is pretty lame anyways
*)

let Build_Number_Array (char_array : char []) index =
    int char_array.[ index ] - int '0';;

let Problem8_v1 n =
    let file_stream = File.OpenText "Data//Problem8.txt"
    let number_string = file_stream.ReadLine()
    let char_array = number_string.ToCharArray()
    let number_array = Array.init char_array.Length <| Build_Number_Array char_array

    let product_count = number_array.Length - n;
    let result_array = Array.zeroCreate product_count

    if product_count <= 0 then
        0
    else
        for i = 0 to product_count - 1 do
            let mutable base_product = 1;
            for j = 0 to n - 1 do
                base_product <- base_product * number_array.[ i + j ]

            result_array.[ i ] <- base_product

        Array.max result_array;;

let Problem8_v1_Interactive() =
    printfn "Problem 8: Find the greatest product of five consecutive digits in the 1000-digit number specified in Problem8.txt, where N = 5."
    printfn "Input alternate N:"
    let N_string = Console.ReadLine()
    let success, N = Int32.TryParse N_string
    if success = true then
        let result_N = Problem8_v1 N
        printfn "For N = %d, the answer is %d" N result_N
    ();;