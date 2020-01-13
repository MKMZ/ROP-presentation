namespace SampleClinic.UseCases

open SampleClinic.UseCases.Statuses
open SampleClinic.UseCases.Commands
open SampleClinic.Domain
open SampleClinic.Repositories
open SampleClinic.Shared

type ReserveDoctorAppointmentUseCaseContext() = 
    member val Doctor: Doctor = null with get, set
    static member SetDoctor(context: ReserveDoctorAppointmentUseCaseContext) (doctor: Doctor) =
        context.Doctor = doctor
        context
    member val Patient: Patient = null with get, set
    static member SetPatient(context: ReserveDoctorAppointmentUseCaseContext) (patient: Patient) =
        context.Patient = patient
        context
    member val PatientPackage: PatientPackage = null with get, set
    static member SetPatientPackage(context: ReserveDoctorAppointmentUseCaseContext) (patientPackage: PatientPackage) =
        context.PatientPackage = patientPackage
        context

