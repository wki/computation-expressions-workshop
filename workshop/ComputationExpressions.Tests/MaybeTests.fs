module Tests
open System.IO
open Xunit
open ComputationExpressions.Maybe

[<Fact>]
let ``maybe with one value returns Some(value)`` () =
    let expected = 1
    let actual = maybe { return expected }
    Assert.Equal(actual, Some expected)

[<Fact>]
let ``maybe with unresolvable value returns None`` () =
    let actual = maybe {
        let! a = Some 1
        let! b = None
        return a+b
    }
    Assert.Equal(actual, None)

[<Fact>]
let ``maybe with resolvable values returns Some(sum)`` () =
    let expected = 42
    let actual = maybe {
        let! a = Some 40
        let! b = Some 2
        return a+b
    }
    Assert.Equal(actual, Some expected)

[<Fact>]
let ``maybe can exist without return`` () =
    let tmpFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())
    let tmpContent = "foo bar"

    maybe {
        let! file = Some tmpFile
        let! content = Some tmpContent
        File.WriteAllText(file, content)
    } |> ignore

    Assert.Equal(tmpContent, File.ReadAllText(tmpFile))
    File.Delete(tmpFile)

[<Fact>]
let ``maybe allows to return a computed None value`` () =
    let result = maybe {
        if true then
            return! None
        else
            let! a = Some 40
            let! b = Some 2
            return a+b
    }

    Assert.Equal(None, result)

[<Fact>]
let ``maybe allows to return a computed Some() value`` () =
    let expected = 13

    let result = maybe {
        if true then
            return! Some expected
        else
            let! a = Some 40
            let! b = None
            return a+b
    }

    Assert.Equal(Some expected, result)
