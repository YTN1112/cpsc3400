open System

let rec maxCylinderVolume rhList =
    match rhList with
    | [] -> 0.0
    | (r, h) :: tl ->
        let maxVal = maxCylinderVolume tl
        let calc = r * r * h * Math.PI
        if calc > maxVal then calc else maxVal

let rec elimDuplicates ilist =
    match ilist with
    | [] -> []
    | [x] -> [x]
    | x :: y:: tl ->
        if x = y then
            elimDuplicates (y :: tl)
        else
            x :: elimDuplicates (y :: tl)

    
let rec insert dict key value =
    match dict with
    | [] -> [(key, value)]
    | (string,int) :: tl->
        if string = key then
            dict
        else
            (string, int) :: insert tl key value

let rec remove dict key =
    match dict with
    | [] -> []
    | (string,int) :: tl->
        if string = key then
            remove tl key
        else
            (string, int) :: remove tl key

let rec count dict func =
    match dict with
    | []-> 0
    | (key, value) :: tl ->
        if func value then
            1 + count tl func
        else
            count tl func

let sameDigitCount dict =
    let returnvalue = count dict (fun value -> value % 11 = 0 && value > 0 && value < 100) 
    returnvalue



