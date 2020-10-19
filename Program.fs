open Expecto

[<Tests>]
let tests =
    test "it works" { Expect.equal 1 1 "1==1" }

[<EntryPoint>]
let main argv =
    Tests.runTestsInAssembly defaultConfig argv
