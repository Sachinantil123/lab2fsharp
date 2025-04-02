// ==============================================
// Part 1: NBA Records (Question 1)
// ==============================================

// Define a Coach record to store coach details
type Coach = {
    Name: string          // Name of the coach
    FormerPlayer: bool    // Indicates if the coach was a former NBA player
}

// Define a Stats record to track wins and losses
type Stats = {
    Wins: int             // Number of games won
    Losses: int           // Number of games lost
}

// Define a Team record to represent an NBA team
type Team = {
    Name: string          // Name of the team
    Coach: Coach          // Coach of the team (uses Coach record)
    Stats: Stats          // Win/loss stats (uses Stats record)
}

// ----------------------------------------------------------------------
// Sample Data: Create instances of coaches, stats, and teams
// ----------------------------------------------------------------------

// Team 1: Golden State Warriors
let coach1 = { 
    Name = "Steve Kerr" 
    FormerPlayer = true   // Steve Kerr was a former NBA player
}
let stats1 = { 
    Wins = 50 
    Losses = 20 
}
let team1 = { 
    Name = "Warriors" 
    Coach = coach1 
    Stats = stats1 
}

// Team 2: Miami Heat
let coach2 = { 
    Name = "Erik Spoelstra" 
    FormerPlayer = false  // Erik Spoelstra was not an NBA player
}
let stats2 = { 
    Wins = 45 
    Losses = 25 
}
let team2 = { 
    Name = "Heat" 
    Coach = coach2 
    Stats = stats2 
}

// Team 3: Philadelphia 76ers
let coach3 = { 
    Name = "Doc Rivers" 
    FormerPlayer = true 
}
let stats3 = { 
    Wins = 40 
    Losses = 30 
}
let team3 = { 
    Name = "76ers" 
    Coach = coach3 
    Stats = stats3 
}

// Team 4: San Antonio Spurs
let coach4 = { 
    Name = "Gregg Popovich" 
    FormerPlayer = false 
}
let stats4 = { 
    Wins = 35 
    Losses = 35 
}
let team4 = { 
    Name = "Spurs" 
    Coach = coach4 
    Stats = stats4 
}

// Team 5: LA Clippers
let coach5 = { 
    Name = "Tyronn Lue" 
    FormerPlayer = true 
}
let stats5 = { 
    Wins = 55 
    Losses = 15 
}
let team5 = { 
    Name = "Clippers" 
    Coach = coach5 
    Stats = stats5 
}

// Combine all teams into a list
let teams = [ team1; team2; team3; team4; team5 ]

// ----------------------------------------------------------------------
// Filtering: Find teams with more wins than losses
// ----------------------------------------------------------------------
let successfulTeams = 
    teams 
    |> List.filter (fun team -> 
        team.Stats.Wins > team.Stats.Losses  // Filter condition: wins > losses
    )

// ----------------------------------------------------------------------
// Mapping: Calculate success percentage for each team
// ----------------------------------------------------------------------
let successPercentages = 
    teams 
    |> List.map (fun team ->
        let totalGames = float (team.Stats.Wins + team.Stats.Losses)
        let winPercentage = (float team.Stats.Wins / totalGames) * 100.0  // Convert to float for accurate division
        winPercentage
    )

// ----------------------------------------------------------------------
// Print Results
// ----------------------------------------------------------------------
printfn "Successful Teams (Wins > Losses):"
successfulTeams |> List.iter (fun t -> 
    printfn $"- {t.Name}: {t.Stats.Wins} wins, {t.Stats.Losses} losses"
)

printfn "\nSuccess Percentages:"
teams 
|> List.iteri (fun i t ->
    let percentage = successPercentages.[i]
    printfn $"- {t.Name}: {percentage:F2}%%"  // Format to 2 decimal places
)