using Convey;
using Convey.Persistence.MongoDB;
using SalesManager.Availability.Infrastructure.Mongo.Documents;
using System;

namespace SalesManager.Availability.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder
                .AddMongo()
                .AddMongoRepository<ResourceDocument, Guid>("resources");

            return builder;
        }
    }
}
