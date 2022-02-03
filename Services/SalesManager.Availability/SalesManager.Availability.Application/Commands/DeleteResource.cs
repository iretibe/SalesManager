using System;
using Convey.CQRS.Commands;

namespace SalesManager.Availability.Application.Commands
{
    [Contract]
    public class DeleteResource : ICommand
    {
        public Guid ResourceId { get; }

        public DeleteResource(Guid resourceId)
            => ResourceId = resourceId;
    }
}