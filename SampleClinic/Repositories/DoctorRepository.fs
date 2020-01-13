namespace SampleClinic.Repositories

open SampleClinic.Domain

module DoctorRepository =

    let getById (doctorId: string) =
        match doctorId with
        | "1" | "2" | "3" | "5" -> Doctor.Create(doctorId, true)
        | _ -> Doctor.Create(doctorId, false)

