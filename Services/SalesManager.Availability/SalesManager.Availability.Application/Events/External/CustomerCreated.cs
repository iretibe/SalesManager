using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace SalesManager.Availability.Application.Events.External
{
    [Message("customers")]
    public class CustomerCreated : IEvent
    {
        public Guid CustomerId { get; }

        public CustomerCreated(Guid customerId)
            => CustomerId = customerId;
    }
}