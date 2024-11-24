open System

let maxCylinderVolume rhList =
    let calc (r, h) = r * r * h * Math.PI
    List.map calc rhList |> List.max

let elimDuplicates ilist =
    List.distinct ilist

let insert dict key value =
    if List.exists (fun (k, _) -> k = key) dict then
        dict
    else
        (key, value) :: dict

let remove dict key =
    List.filter (fun (k, _) -> k <> key) dict

let count dict func =
    List.filter (fun (_, v) -> func v) dict |> List.length

let sameDigitCount dict =
    count dict (fun value -> value % 11 = 0 && value > 0 && value < 100)

// Test cases
let testRhList = [(1.0, 2.0); (3.0, 4.0); (5.0, 6.0)]
let testIlist = [1; 2; 2; 3; 4; 4; 5]
let testDict = [("a", 10); ("b", 20); ("c", 30)]

printfn "Max cylinder volume: %f" (maxCylinderVolume testRhList)
printfn "Distinct list: %A" (elimDuplicates testIlist)
printfn "Dictionary after inserting (d, 40): %A" (insert testDict "d" 40)
printfn "Dictionary after removing b: %A" (remove testDict "b")
printfn "Count of values divisible by 11: %d" (sameDigitCount testDict)