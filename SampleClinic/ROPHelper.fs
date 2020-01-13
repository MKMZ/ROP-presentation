namespace SampleClinic.Shared

open System
open FSharpPlus


/// **Description**
/// Provides supporting methods for Railway-Oriented Programming
/// Good article about this approach is available here:
/// https://fsharpforfunandprofit.com/posts/recipe-part2/
///
module ROPHelper =

    /// **Description**
    /// Evaulates exception from defining Error state object
    /// **Parameters**
    ///   * `x` - generic type `'A` which defines Error state
    /// **Output Type**
    ///   * `exn` - Exception object
    let private evaluateExceptionFrom (x: 'A): exn =
        match box x with
        | :? Exception as ex -> ex
        | :? string as msg -> exn msg
        | other -> other.ToString() |> exn

    
    /// **Description**
    /// Executes specific input function depend on monadic value
    /// **Parameters**
    ///   * `successFunc` - function executed on monadic Ok type
    ///   * `failureFunc` - function executed on monadic Error type
    ///   * `twoTrackInput` - monadic input value
    ///
    /// **Output Type**
    ///   * `Result<'C,'D>`- monadic Result value
    ///
    let DoubleMap (successFunc: 'A -> 'C) (failureFunc: 'B -> 'D) (twoTrackInput: Result<'A, 'B>): Result<'C, 'D> =
        match twoTrackInput with
        | Ok s -> Ok(successFunc s)
        | Error f -> Error(failureFunc f)

    
    /// **Description**
    /// Packs result of input function into monadic success value
    /// WARNING: Does not catch exceptions from executed input function
    /// **Parameters**
    ///   * `f` - input function
    ///   * `x` - argument to input function
    ///
    /// **Output Type**
    ///   * `Result<'B,'a>`- monadic Result value
    ///
    let ToOk (f: 'A -> 'B) (x: 'A): Result<'B, _> = 
        f x |> Ok

    
    /// **Description**
    /// Packs result of input function into monadic value with catching exceptions
    /// **Parameters**
    ///   * `f` - input function
    ///   * `x` - argument to input function
    ///
    /// **Output Type**
    ///   * `Result<'B,exn>`- monadic Result value
    ///
    let TryCatch (f: 'A -> 'B) (x: 'A): Result<'B, exn> =
        try
            ToOk f x
        with ex -> Error ex


    
    /// **Description**
    /// Runs dead-end input functions with specific argument and returns argument
    /// **Parameters**
    ///   * `f` - input dead-end function
    ///   * `x` - argument to input function
    ///
    /// **Output Type**
    ///   * `'A` - argument to input function
    ///
    let Tee (f: 'A -> unit) (x: 'A): 'A =
        f x
        x

    
    /// **Description**
    ///  Extract content value from success monadic object or throws an exception
    /// **Parameters**
    ///   * `x` - monadic object
    ///
    /// **Output Type**
    ///   * `'A` - content value of monadic object
    ///
    let GetValueOrThrow(x: Result<'A, _>): 'A =
        match x with
        | Ok s -> s
        | Error f -> evaluateExceptionFrom f |> raise

    
    /// **Description**
    /// Runs sequentially array of monadic functions and returns monadic value from the end
    /// **Parameters**
    ///   * `x` - argument to first input function
    ///   * `fArray` - array of input monadic functions
    ///
    /// **Output Type**
    ///   * `Result<'A,'a>`- result from monadic array of functions
    ///
    let FoldenBind (x: 'A) (fArray: ('A -> Result<'A, _>) []): Result<'A, _> =
        fArray 
        |> Array.fold 
            (fun (acc: Result<'A, _>) (f: 'A -> Result<'A, _>) -> (acc >>= f)) 
            (Ok x)
