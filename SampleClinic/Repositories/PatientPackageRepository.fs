namespace SampleClinic.Repositories

open SampleClinic.Domain

module PatientPackageRepository =

    let getByPatient (patient: Patient) =
        match patient.Id with
        | "1" | "3" | "5" -> PatientPackage.CreateFull(patient.Id)
        | _ -> PatientPackage.CreateBlocked(patient.Id)

