using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SalesManager.Availability.Tests.Unit")]
namespace SalesManager.Availability.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
            => builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher();
    }
}