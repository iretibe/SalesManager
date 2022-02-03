using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System;

namespace SalesManager.Availability.Application.Events.External
{
    [Message("vehicles")]
    public class VehicleDeleted : IEvent
    {
        public Guid VehicleId { get; }

        public VehicleDeleted(Guid vehicleId)
            => VehicleId = vehicleId;
    }
}
