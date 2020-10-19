namespace ComputationExpressions
module Maybe =

    type OptionBuilder() =
        class
            member this.Return(x) = Some x
            member this.Bind(m,f) = Option.bind f m
            member this.Zero() = Some ()
        end

    let maybe = OptionBuilder()
