open System

let len (length: int) (seq: seq<string>) =
    seq |> Seq.fold (fun acc s -> 
        if s.Length = length 
        then acc + 1 
        else acc) 0

let rec colstrok() =
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | _ ->
        printfn "Error number is no avelibale"
        colstrok()

let rec lenstrok (seq: seq<string>) =
    printf "\nEnter len to find: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, length) when length >= 0 ->
        let result = len length seq
        printfn "\n col strok dliny %d: %d" length result
        lenstrok seq 
    | _ ->
        printfn "Error: enter norm chislo"
        lenstrok seq 


let askK() =
    printf "enter k: "
    Console.ReadLine()

let readstroka(index: int) =
    printf "Enter strok %d: " (index)
    Console.ReadLine()

let addstroka(count: int) =
    seq { for i in 1 .. count -> readstroka i }

let add (k: string) (s: string) =
    k + s

let uni k strings =
    Seq.map (add k) strings

let print before after =
    printfn "\n Seq + k:"
    Seq.iteri (fun i s -> printfn "  %d- \"%s\"" (i + 1) s) after



let quest1() =
    printf "Enter col strok: "
    let count = colstrok()
    let k = askK()
    printfn "\n Enter %d strok:" count
    let seq = addstroka count
    let seq2 = uni k seq
    print seq seq2
    0

let quest2() =
    printf "Enter col strok: "
    let count = colstrok()
    printfn "\n Enter %d strok:" count
    let seq = addstroka count
    lenstrok seq
    0
let rec ask_quest() =
    printf "Enter zadanie 1 or 2 : "
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