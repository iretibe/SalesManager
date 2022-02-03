using System;

namespace SalesManager.Availability.Application.Exceptions
{
    public class ResourceAlreadyExistsException : AppException
    {
        public ResourceAlreadyExistsException(Guid id) : base($"Resource with '{id}' already exists.")
        {

        }
    }
}
