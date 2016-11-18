namespace MyNamespace

module FizzBuzz =
    let GetValue x = 
        match x with
        | i when i%15 = 0 -> "FizzBuzz"
        | i when i%3 = 0 -> "Fizz"
        | i when i%5 = 0 -> "Buzz"
        | _ -> sprintf "%i" x
    
   
    let DoTheFizzBuzz x = 
        let folder currentString (number, str) = sprintf "%s %i -> %s\n"  currentString number str
        
        let values = [1 .. x]

        List.map GetValue values
        |> List.zip values
        |> List.fold folder ""
    

