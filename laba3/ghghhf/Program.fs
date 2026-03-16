open System

let len (length: int) (seq: seq<string>) =
    seq |> Seq.fold (fun acc s -> 
        if s.Length = length 
        then acc + 1 
        else acc) 0

let rec amountline() =
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | _ ->
        printfn "Error number is no avelibale"
        amountline()

let rec lenline (seq: seq<string>) =
    printf "\nEnter len to find: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, length) when length >= 0 ->
        let result = len length seq
        printfn "\n amount line lenght %d: %d" length result
        //lenline seq 
    | _ ->
        printfn "Error: enter good number"
        lenline seq 


let askK() =
    printf "enter k: "
    Console.ReadLine()

let readline(index: int) =
    printf "Enter line %d: " (index)
    Console.ReadLine()

let addline(count: int) =
    seq { for i in 1 .. count -> readline i }

let add (k: string) (s: string) =
    k + s

let uni k strings =
    Seq.map (add k) strings

let print before after =
    printfn "\n Seq + k:"
    Seq.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) after



let quest1() =
    printf "Enter amount line: "
    let count = amountline()
    let k = askK()
    printfn "\n Enter %d line:" count
    let seq = addline count
    let seq2 = uni k seq
    print seq seq2
    0

let quest2() =
    printf "Enter amount line: "
    let count = amountline()
    printfn "\n Enter %d line:" count
    let seq = addline count
    lenline seq
    0
let rec ask_quest() =
    printf "Enter quest 1 or 2 : "
    let quest = int(Console.ReadLine())
    match quest with
    | 1 -> quest1()  
    | 2 -> quest2()
    | _ when quest > 2 -> 
        printf "\n Error number quest  \n"
        ask_quest() 


[<EntryPoint>]
let main argv =
    ask_quest()
    0 