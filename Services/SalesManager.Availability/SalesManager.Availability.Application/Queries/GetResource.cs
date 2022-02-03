using Convey.CQRS.Queries;
using SalesManager.Availability.Application.DTO;
using System;

namespace SalesManager.Availability.Application.Queries
{
    public class GetResource : IQuery<ResourceDto>
    {
        public Guid ResourceId { get; set; }
    }
}
