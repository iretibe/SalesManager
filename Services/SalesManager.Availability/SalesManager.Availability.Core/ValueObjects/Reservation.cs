using System;

namespace SalesManager.Availability.Core.ValueObjects
{
    public struct Reservation : IEquatable<Reservation>
    {
        public DateTime ReservationDateTime { get; }
        public int ReservationPriority { get; }

        public Reservation(DateTime reservationDateTime, int reservationPriority)
        {
            ReservationDateTime = reservationDateTime;
            ReservationPriority = reservationPriority;
        }

        public bool Equals(Reservation other)
        {
            return ReservationDateTime.Equals(other.ReservationDateTime) && ReservationPriority == other.ReservationPriority;
        }

        public override bool Equals(object obj)
        {
            return obj is Reservation other && Equals(obj);
        }


    }
}
