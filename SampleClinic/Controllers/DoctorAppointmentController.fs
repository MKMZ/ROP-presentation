namespace SampleClinic.Controllers

open Microsoft.AspNetCore.Mvc
open SampleClinic.UseCases.Commands
open SampleClinic.UseCases


[<Route("api/[controller]")>]
[<ApiController>]
type DoctorAppointmentController () =
    inherit ControllerBase()

    [<HttpPost>]
    member this.Reserve(command: ReserveDoctorAppointmentCommand) =
        ReserveDoctorAppointmentUseCase.Run command


