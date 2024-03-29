﻿using Convey.CQRS.Queries;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SalesManager.Availability.Application.DTO;
using SalesManager.Availability.Application.Queries;
using SalesManager.Availability.Infrastructure.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManager.Availability.Infrastructure.Mongo.Queries.Handlers
{
    internal sealed class GetResourcesHandler : IQueryHandler<GetResources, IEnumerable<ResourceDto>>
    {
        private readonly IMongoDatabase _database;

        public GetResourcesHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<ResourceDto>> HandleAsync(GetResources query)
        {
            var collection = _database.GetCollection<ResourceDocument>("resources");

            if (query.Tags is null || !query.Tags.Any())
            {
                var allDocuments = await collection.Find(_ => true).ToListAsync();

                return allDocuments.Select(d => d.AsDto());
            }

            var documents = collection.AsQueryable();

            documents = query.MatchAllTags
                ? documents.Where(d => query.Tags.All(t => d.Tags.Contains(t)))
                : documents.Where(d => query.Tags.Any(t => d.Tags.Contains(t)));

            var resources = await documents.ToListAsync();

            return resources.Select(d => d.AsDto());
        }
    }
}
