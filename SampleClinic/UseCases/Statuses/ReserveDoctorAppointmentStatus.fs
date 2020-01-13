namespace SampleClinic.UseCases.Statuses

type ReserveDoctorAppointmentStatus private (reservationId: string, status: string) = 
    member val ReservationId = reservationId with get
    static member GetReservationId(reservationStatus: ReserveDoctorAppointmentStatus) = reservationStatus.ReservationId
    member val Status = status with get
    static member GetStatus(reservationStatus: ReserveDoctorAppointmentStatus) = reservationStatus.Status

    static member createSuccessfull(id: string) = ReserveDoctorAppointmentStatus(id, "RESERVED")
    static member CreateFailed() = ReserveDoctorAppointmentStatus(null, "FAILURE")
