using SalesManager.Availability.Core.Entities;

namespace SalesManager.Availability.Core.Events
{
    public class ReasourceCreated : IDomainEvent
    {
        public Resource Resource { get; }

        public ReasourceCreated(Resource resource) => Resource = resource;
    }
}
