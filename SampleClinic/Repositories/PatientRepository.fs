namespace SampleClinic.Repositories

open SampleClinic.Domain

module PatientRepository =

    let getById (patientId: string) =
        match patientId with
        | "1" | "2" | "3" | "5" -> Patient.Create(patientId, true)
        | _ -> Patient.Create(patientId, false)

