using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SalesManager.Availability.Core.Repositories;
using SalesManager.Availability.Infrastructure.Mongo.Documents;
using SalesManager.Availability.Infrastructure.Mongo.Repositories;
using System;

namespace SalesManager.Availability.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IResourcesRepository, ResourcesMongoRepository>();

            builder
                .AddMongo()
                .AddMongoRepository<ResourceDocument, Guid>("resources");

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseConvey();

            return app;
        }
    }
}
