using System;
using Convey.CQRS.Commands;

namespace SalesManager.Availability.Application.Commands
{
    [Contract]
    public class ReleaseResourceReservation : ICommand
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }

        public ReleaseResourceReservation(Guid resourceId, DateTime dateTime)
            => (ResourceId, DateTime) = (resourceId, dateTime);
    }
}