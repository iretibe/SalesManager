using System;
using Convey.CQRS.Events;

namespace SalesManager.Availability.Application.Events
{
    [Contract]
    public class ResourceDeleted : IEvent
    {
        public Guid ResourceId { get; }

        public ResourceDeleted(Guid resourceId)
            => ResourceId = resourceId;
    }
}