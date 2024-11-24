open System

// Calculate the maximum cylinder volume
let maxCylinderVolume rhList =
    // Define a function to calculate the volume of a cylinder
    let calc (r, h) = r * r * h * Math.PI
    
    // Use List.map to apply the calc function to each element in the list
    let volumes = List.map calc rhList
    
    // Check if the list is empty
    if List.isEmpty volumes then
        // If the list is empty, return 0.0
        0.0
    else
        // If the list is not empty, use List.max to find the maximum volume
        List.max volumes

// Remove consecutive duplicates from a list
let elimDuplicates ilist =
    // Define a recursive function to remove duplicates
    let rec elimDuplicatesRec acc = function
        // If the list is empty, return the accumulator
        | [] -> List.rev acc
        // If the list has only one element, add it to the accumulator and return
        | [x] -> List.rev (x :: acc)
        // If the list has at least two elements, check if they are equal
        | x :: y :: tl ->
            // If the elements are equal, skip the first one and recurse
            if x = y then elimDuplicatesRec acc (y :: tl)
            // If the elements are not equal, add the first one to the accumulator and recurse
            else elimDuplicatesRec (x :: acc) (y :: tl)
    
    // Call the recursive function with an empty accumulator
    elimDuplicatesRec [] ilist

// Insert a key-value pair into a dictionary
let insert dict key value =
    // Define a recursive function to insert the key-value pair
    let rec insertRec = function
        // If the dictionary is empty, return a new dictionary with the key-value pair
        | [] -> [(key, value)]
        // If the dictionary is not empty, check if the key already exists
        | (k, v) :: tl ->
            // If the key already exists, update its value and return the updated dictionary
            if k = key then (k, value) :: tl
            // If the key does not exist, add the key-value pair to the dictionary and return
            else (k, v) :: insertRec tl
    
    // Call the recursive function
    insertRec dict

// Remove all occurrences of a key from a dictionary
let remove dict key =
    // Define a recursive function to remove the key
    let rec removeRec = function
        // If the dictionary is empty, return an empty dictionary
        | [] -> []
        // If the dictionary is not empty, check if the key matches the current key
        | (k, v) :: tl ->
            // If the key matches, skip the current key-value pair and recurse
            if k = key then removeRec tl
            // If the key does not match, add the current key-value pair to the result and recurse
            else (k, v) :: removeRec tl
    
    // Call the recursive function
    removeRec dict

// Count the number of values in a dictionary that satisfy a predicate
let count dict func =
    // Define a recursive function to count the values
    let rec countRec acc = function
        // If the dictionary is empty, return the accumulator
        | [] -> acc
        // If the dictionary is not empty, check if the current value satisfies the predicate
        | (_, v) :: tl ->
            // If the value satisfies the predicate, increment the accumulator and recurse
            if func v then countRec (acc + 1) tl
            // If the value does not satisfy the predicate, recurse without incrementing the accumulator
            else countRec acc tl
    
    // Call the recursive function with an initial accumulator of 0
    countRec 0 dict

// Count the number of values in a dictionary that are between 1 and 99 (inclusive) and are multiples of 11
let sameDigitCount dict =
    // Define a predicate function to check if a value is between 1 and 99 (inclusive) and is a multiple of 11
    let predicate value = value % 11 = 0 && value > 0 && value < 100
    
    // Call the count function with the predicate function
    count dict predicate

// Test maxCylinderVolume with an empty list
let cylinderVolumes = []
let maxVolume = maxCylinderVolume cylinderVolumes
printfn "Max cylinder volume: %f" maxVolume

// Test elimDuplicates with an empty list
let numbers = []
let uniqueNumbers = elimDuplicates numbers
printfn "Unique numbers: %A" uniqueNumbers

// Test insert with an empty dictionary
let dict1 = []
let newDict = insert dict1 "c" 3
printfn "New dictionary: %A" newDict

// Test remove with an empty dictionary
let dict2 = []
let updatedDict = remove dict2 "b"
printfn "Updated dictionary: %A" updatedDict

// Test count with an empty dictionary
let dict3 = []
let countResult = count dict3 (fun value -> value % 11 = 0 && value > 0 && value < 100)
printfn "Count: %i" countResult

// Test sameDigitCount with an empty dictionary
let dict4 = []
let sameDigitCountResult = sameDigitCount dict4
printfn "Same digit count: %i" sameDigitCountResult

// Test maxCylinderVolume with a list containing zeros
let cylinderVolumes = [(0.0, 0.0); (0.0, 0.0); (0.0, 0.0)]
let maxVolume = maxCylinderVolume cylinderVolumes
printfn "Max cylinder volume: %f" maxVolume

// Test elimDuplicates with a list containing duplicates
let numbers = [1; 1; 1; 1; 1]
let uniqueNumbers = elimDuplicates numbers
printfn "Unique numbers: %A" uniqueNumbers

// Test insert with a dictionary already containing the key
let dict1 = [("a", 1); ("b", 2); ("c", 3)]
let newDict = insert dict1 "c" 4
printfn "New dictionary: %A" newDict

// Test remove with a dictionary not containing the key
let dict2 = [("a", 1); ("b", 2); ("c", 3)]
let updatedDict = remove dict2 "d"
printfn "Updated dictionary: %A" updatedDict

// Test count with a dictionary containing values that don't satisfy the predicate
let dict3 = [("a", 10); ("b", 20); ("c", 30)]
let countResult = count dict3 (fun value -> value % 11 = 0 && value > 0 && value < 100)
printfn "Count: %i" countResult

// Test sameDigitCount with a dictionary containing values that don't satisfy the predicate
let dict4 = [("a", 10); ("b", 20); ("c", 30)]
let sameDigitCountResult = sameDigitCount dict4
printfn "Same digit count: %i" sameDigitCountResult