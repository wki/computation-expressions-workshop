module ChoiceTests

open Xunit
open ComputationExpressions.Choice

[<Fact>]
let ``a choice returns the first not-None expression`` () =
    let expected = "use this instead"

    let result = choice {
        return! None
        return expected
    }

    Assert.Equal(Some expected, result)
