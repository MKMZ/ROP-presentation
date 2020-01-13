namespace SampleClinic.UseCases

open SampleClinic.UseCases.Statuses
open SampleClinic.UseCases.Commands
open SampleClinic.Domain
open SampleClinic.Repositories
open SampleClinic.Shared
open FSharpPlus

module ReserveDoctorAppointmentUseCase =

    let validateDoctor (context: ReserveDoctorAppointmentUseCaseContext) =
        if (context.Doctor.IsActive)
            then Ok(context)
        else Error "Not correct Doctor"
            

    let Run (command: ReserveDoctorAppointmentCommand) =
        //: Result<ReserveDoctorAppointmentStatus, _> = 
        ROPHelper.TryCatch (fun (context: ReserveDoctorAppointmentUseCaseContext) -> 
            DoctorRepository.getById(command.DoctorId) 
            |> ReserveDoctorAppointmentUseCaseContext.SetDoctor(context) 
        )
        >>= validateDoctor
        

