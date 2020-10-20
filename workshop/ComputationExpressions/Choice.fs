namespace ComputationExpressions
open Maybe
module Choice =
    type ChoiceBuilder() =
        inherit OptionBuilder()
        member this.Combine(m1: 'a option, m2: 'a option) =
            match m1 with
            | Some _ -> m1
            | None -> m2
        member this.Delay(f) =
            f()

    let choice = ChoiceBuilder()
