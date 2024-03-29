﻿namespace MyNamespace

module markov_bot =
    let sample = """
        I see trees of green, red roses, too,
        I see them bloom, for me and you
        And I think to myself
        What a wonderful world.

        I see skies of blue, and clouds of white,
        The bright blessed day, the dark sacred night
        And I think to myself
        What a wonderful world.

        The colors of the rainbow, so pretty in the sky,
        Are also on the faces of people going by.
        I see friends shaking hands, sayin', How do you do?
        They're really sayin', I love you.

        I hear babies cryin'. I watch them grow.
        They'll learn much more than I'll ever know
        And I think to myself
        What a wonderful world
        
        Yes, I think to myself
        What a wonderful world"""
    
    let bigramify (text:string) =    
        text.Split (' ', '\n')
        |> Seq.map (fun s -> s.Trim('"'))
        |> Seq.map (fun s -> s.Trim())        
        |> Seq.filter (fun s -> s <> "")    
        |> Seq.windowed 2
        |> Seq.toArray

    let nextWords (bigrams:string[] seq) (word:string) = 
        bigrams
        |> Seq.filter (fun pair -> pair.[0] = word)
        |> Seq.distinct
        |> Seq.toArray
        |> Array.map (fun pair -> pair.[1])

    let isEndOfSentence (word:string) = 
        let lastChar = word.[word.Length - 1]
        match lastChar with
        | '.'  
        | '?'
        | '!' -> true
        | _ -> false

    let generateWords sample firstWord =
        let rand = System.Random()
        let selectNextWord (nextWords:string[]) =
            nextWords.[rand.Next(nextWords.Length)]
        let bigrams = bigramify sample
        let rec appendWord sentence lastWord =             
            match isEndOfSentence lastWord with
            | true -> sentence
            | false -> 
                let possibleNextWords = nextWords bigrams lastWord
                match possibleNextWords.Length with
                | 0 -> sentence
                | _ -> let nextWord = selectNextWord possibleNextWords
                       appendWord (sentence + " " + nextWord) nextWord

        appendWord firstWord firstWord 


        
