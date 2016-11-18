// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace MyNamespace

module Test = 
    open System
    open Integers
    open BasicFunctions

    [<EntryPoint>]
    let main argv = 
        //printfn "%A" argv

        Console.ReadLine() 
            |> Int32.Parse 
            |> FizzBuzz.DoTheFizzBuzz
            |> printf "%s"

        Console.ReadLine() |> ignore
        0 // return an integer exit code 