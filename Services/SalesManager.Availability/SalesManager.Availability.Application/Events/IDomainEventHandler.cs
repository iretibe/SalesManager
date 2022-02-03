using SalesManager.Availability.Core.Events;
using System.Threading.Tasks;

namespace SalesManager.Availability.Application.Events
{
    public interface IDomainEventHandler<in T> where T : class, IDomainEvent
    {
        Task HandleAsync(T @event);
    }
}
