using Convey.CQRS.Events;
using System;

namespace SalesManager.Availability.Application.Events.Rejected
{
    [Contract]
    public class AddResourceRejected : IRejectedEvent
    {
        public Guid ResourceId { get; }
        public string Reason { get; }
        public string Code { get; }

        public AddResourceRejected(Guid resourceId, string reason, string code)
            => (ResourceId, Reason, Code) = (resourceId, reason, code);
    }
}