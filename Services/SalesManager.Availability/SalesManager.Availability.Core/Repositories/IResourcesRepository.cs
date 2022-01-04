using SalesManager.Availability.Core.Entities;
using System.Threading.Tasks;

namespace SalesManager.Availability.Core.Repositories
{
    public interface IResourcesRepository
    {
        Task AddAsync(Resource resource);
    }
}
