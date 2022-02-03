using Convey.CQRS.Events;
using SalesManager.Availability.Core.Events;
using System.Collections.Generic;

namespace SalesManager.Availability.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}
