namespace MyNamespace

module SimpleEncryption =

    let characters = ['A' .. 'Z']

    let Rotate x char =
        let index = List.findIndex (fun c -> c = char) characters
        let newIndex = (index + x + characters.Length) % characters.Length
        characters.[newIndex].ToString()

    let Encrypt x plaintext = 
        let RotateX = Rotate x
        String.collect RotateX plaintext 

    let Decrypt x cryptotext =
        let RotateMinusX = Rotate -x
        String.collect RotateMinusX cryptotext

module VigenereCipher = 

    open System

    let characters = ['A' .. 'Z']

    let FindIndex char = List.findIndex (fun c -> c = char) characters

    let RotateOp op (passchar, textchar) =
        let textindex = FindIndex textchar
        let passindex = FindIndex passchar
        let newIndex = ((op textindex passindex) + characters.Length) % characters.Length
        characters.[newIndex].ToString()

    let Rotate = RotateOp (+)

    let RotateBack = RotateOp (-)

    let BuildPassPhrase password length =
        let passLength = String.length password
        [0..length]
        |> List.map (fun i -> password.[i % passLength])
        |> String.Concat
    
    let DoVigenere rotation pass plaintext =
        let passPhrase = BuildPassPhrase pass <| String.length plaintext
        Seq.zip passPhrase plaintext
        |> Seq.map rotation
        |> String.Concat

    let Encrypt pass plaintext = DoVigenere Rotate pass plaintext

    let Decrypt pass cryptotext = DoVigenere RotateBack pass cryptotext