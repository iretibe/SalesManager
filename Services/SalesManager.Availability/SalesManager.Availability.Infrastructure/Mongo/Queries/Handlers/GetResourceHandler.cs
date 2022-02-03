using Convey.CQRS.Queries;
using MongoDB.Driver;
using SalesManager.Availability.Application.DTO;
using SalesManager.Availability.Application.Queries;
using SalesManager.Availability.Infrastructure.Mongo.Documents;
using System.Threading.Tasks;

namespace SalesManager.Availability.Infrastructure.Mongo.Queries.Handlers
{
    internal sealed class GetResourceHandler : IQueryHandler<GetResource, ResourceDto>
    {
        private readonly IMongoDatabase _database;

        public GetResourceHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<ResourceDto> HandleAsync(GetResource query)
        {
            var document = await _database.GetCollection<ResourceDocument>("resources")
                .Find(r => r.Id == query.ResourceId)
                .SingleOrDefaultAsync();

            return document?.AsDto();
        }
    }
}
