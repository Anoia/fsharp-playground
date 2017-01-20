// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace MyNamespace

module Test = 
    open System
    open Integers
    open BasicFunctions
    open System.IO

    let print text = 
       printfn "%s"text
       text

    [<EntryPoint>]
    let main argv = 
        //printfn "%A" argv
        let text = File.ReadAllText "Tarzan.txt"

        while Console.ReadKey().KeyChar <> 'q' do
            let result = markov_bot.generateWords text "The"
            Console.WriteLine result

        //Console.ReadLine() |> ignore
        0 // return an integer exit code 