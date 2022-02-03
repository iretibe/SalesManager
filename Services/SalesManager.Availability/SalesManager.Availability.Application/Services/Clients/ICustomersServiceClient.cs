using SalesManager.Availability.Application.DTO;
using System;
using System.Threading.Tasks;

namespace SalesManager.Availability.Application.Services.Clients
{
    public interface ICustomersServiceClient
    {
        Task<CustomerStateDto> GetStateAsync(Guid id);
    }
}
