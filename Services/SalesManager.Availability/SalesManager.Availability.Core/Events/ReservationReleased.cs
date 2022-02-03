using SalesManager.Availability.Core.Entities;
using SalesManager.Availability.Core.ValueObjects;

namespace SalesManager.Availability.Core.Events
{
    public class ReservationReleased : IDomainEvent
    {
        public Resource Resource { get; }
        public Reservation Reservation { get; }

        public ReservationReleased(Resource resource, Reservation reservation)
            => (Resource, Reservation) = (resource, reservation);
    }
}