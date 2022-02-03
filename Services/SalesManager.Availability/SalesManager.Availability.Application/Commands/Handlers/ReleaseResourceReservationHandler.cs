using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using SalesManager.Availability.Application.Exceptions;
using SalesManager.Availability.Application.Services;
using SalesManager.Availability.Core.Repositories;

namespace SalesManager.Availability.Application.Commands.Handlers
{
    internal sealed class ReleaseResourceReservationHandler : ICommandHandler<ReleaseResourceReservation>
    {
        private readonly IResourcesRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public ReleaseResourceReservationHandler(IResourcesRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }
        
        public async Task HandleAsync(ReleaseResourceReservation command)
        {
            var resource = await _repository.GetAsync(command.ResourceId);
            
            if (resource is null)
            {
                throw new ResourceNotFoundException(command.ResourceId);
            }

            var reservation = resource.Reservations.FirstOrDefault(r => r.DateTime.Date == command.DateTime.Date);
            
            resource.ReleaseReservation(reservation);
            
            await _repository.UpdateAsync(resource);
            
            await _eventProcessor.ProcessAsync(resource.Events);
        }
    }
}