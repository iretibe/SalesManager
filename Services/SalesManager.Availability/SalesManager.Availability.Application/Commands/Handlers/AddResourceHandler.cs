using Convey.CQRS.Commands;
using SalesManager.Availability.Application.Exceptions;
using SalesManager.Availability.Application.Services;
using SalesManager.Availability.Core.Entities;
using SalesManager.Availability.Core.Repositories;
using System.Threading.Tasks;

namespace SalesManager.Availability.Application.Commands.Handlers
{
    internal sealed class AddResourceHandler : ICommandHandler<AddResource>
    {
        private readonly IResourcesRepository _resourcesRepository;
        private readonly IEventProcessor _eventProcessor;

        public AddResourceHandler(IResourcesRepository resourcesRepository, IEventProcessor eventProcessor)
        {
            _resourcesRepository = resourcesRepository;
            _eventProcessor = eventProcessor;
        }

        public async Task HandleAsync(AddResource command)
        {
            var resource = await _resourcesRepository.GetAsync(command.ResourceId);

            if (resource is {})
            {
                throw new ResourceAlreadyExistsException(command.ResourceId);
            }

            resource = Resource.Create(command.ResourceId, command.Tags);

            await _resourcesRepository.AddAsync(resource);

            await _eventProcessor.ProcessAsync(resource.Events);
        }
    }
}
