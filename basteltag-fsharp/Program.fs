// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace MyNamespace

module Test = 
    open System
    open Integers
    open BasicFunctions

    let print text = 
       printfn "%s"text
       text

    [<EntryPoint>]
    let main argv = 
        //printfn "%A" argv

//        Call FizzBuzz
//        Console.ReadLine() 
//            |> Int32.Parse 
//            |> FizzBuzz.DoTheFizzBuzz
//            |> printf "%s"

        
        let pass = Console.ReadLine()
        

        Console.ReadLine()
            |> VigenereCipher.Encrypt pass
            |> print
            |> VigenereCipher.Decrypt pass
            |> print
            |> ignore

        Console.ReadLine() |> ignore
        0 // return an integer exit code 