using System;
using Convey.CQRS.Events;

namespace SalesManager.Availability.Application.Events
{
    [Contract]
    public class ResourceAdded : IEvent
    {
        public Guid ResourceId { get; }

        public ResourceAdded(Guid resourceId)
            => ResourceId = resourceId;
    }
}