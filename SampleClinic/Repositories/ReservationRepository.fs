namespace SampleClinic.Repositories

open SampleClinic.Domain
open System

module ReservationRepository =

    let makeReservation (doctor: Doctor) (patient: Patient) (startDate: DateTime) (endDate: DateTime) =
        Guid.NewGuid().ToString()
