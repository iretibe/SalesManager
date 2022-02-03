using Convey.CQRS.Queries;
using SalesManager.Availability.Application.DTO;
using System.Collections.Generic;

namespace SalesManager.Availability.Application.Queries
{
    public class GetResources : IQuery<IEnumerable<ResourceDto>>
    {
        public IEnumerable<string> Tags { get; set; }
        public bool MatchAllTags { get; set; }
    }
}
