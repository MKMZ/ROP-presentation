namespace SampleClinic.UseCases.Commands

open System

type ReserveDoctorAppointmentCommand (doctorId: string, patientId: string, startDate: DateTime, endDate: DateTime) =
    member val DoctorId = doctorId with get
    member val PatientId = patientId with get
    member val StartDate = startDate with get
    member val EndDate = endDate with get