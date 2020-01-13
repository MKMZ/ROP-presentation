namespace SampleClinic.Domain

type Doctor private (id: string, isActive: bool) =
    member val Id = id with get
    member val IsActive = isActive with get

    static member Create(id: string, isActive: bool) =
        Doctor(id, isActive)
