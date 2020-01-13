namespace SampleClinic.Domain

type PatientPackage private (patientId: string, packageType: string) =
    member val PatientId = patientId with get
    member val PackageType = packageType with get

    static member CreateFull(patientId: string) = PatientPackage(patientId, "FULL")
    static member CreateBlocked(patientId: string) = PatientPackage(patientId, "BLOCKED")

    static member CanAppointTo(doctor: Doctor) (patientPackage: PatientPackage) =
        doctor.IsActive && patientPackage.PackageType <> "BLOCKED"
