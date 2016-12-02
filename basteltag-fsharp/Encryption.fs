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