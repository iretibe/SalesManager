using SalesManager.Availability.Core.Entities;
using SalesManager.Availability.Core.ValueObjects;

namespace SalesManager.Availability.Core.Events
{
    public class ReservationAdded : IDomainEvent
    {
        public Resource Resource { get; }
        public Reservation Reservation { get; }

        public ReservationAdded(Resource resource, Reservation reservation)
            => (Resource, Reservation) = (resource, reservation);
    }
}