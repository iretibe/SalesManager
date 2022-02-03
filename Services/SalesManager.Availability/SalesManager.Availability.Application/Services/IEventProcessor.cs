using SalesManager.Availability.Core.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManager.Availability.Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}