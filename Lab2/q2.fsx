// Discriminated Unions for Valentine's Day Budget
type Cuisine = 
    | Korean 
    | Turkish

type MovieType = 
    | Regular 
    | IMAX 
    | DBOX 
    | RegularWithSnacks 
    | IMAXWithSnacks 
    | DBOXWithSnacks

type Activity = 
    | BoardGame 
    | Chill 
    | Movie of MovieType 
    | Restaurant of Cuisine 
    | LongDrive of int * float 

// Calculate budget based on activity
let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 17.0  // 12 + 5
        | IMAXWithSnacks -> 22.0     // 17 + 5
        | DBOXWithSnacks -> 25.0    // 20 + 5
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (km, fuelPerKm) -> float km * fuelPerKm

// Example usage
let movieNight = Movie IMAXWithSnacks
let dinner = Restaurant Korean
let drive = LongDrive (100, 0.15)

printfn "Movie Night Cost: %.2f CAD" (calculateBudget movieNight)
printfn "Dinner Cost: %.2f CAD" (calculateBudget dinner)
printfn "Long Drive Cost: %.2f CAD" (calculateBudget drive)