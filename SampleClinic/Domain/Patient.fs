namespace SampleClinic.Domain

type Patient private (id: string, isActive: bool) =
    member val Id = id with get
    member val IsActive = isActive with get

    static member Create(id: string, isActive: bool) =
        Patient(id, isActive)