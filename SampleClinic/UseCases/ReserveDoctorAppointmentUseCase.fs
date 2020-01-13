namespace SampleClinic.UseCases

open SampleClinic.UseCases.Statuses
open SampleClinic.UseCases.Commands

module ReserveDoctorAppointmentUseCase =
    
    let Run (command: ReserveDoctorAppointmentCommand)
        : Result<ReserveDoctorAppointmentStatus, _> = 
        Ok(ReserveDoctorAppointmentStatus.CreateFailed())
        
