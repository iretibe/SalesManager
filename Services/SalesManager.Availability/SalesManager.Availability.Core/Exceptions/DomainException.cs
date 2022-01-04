using System;

namespace SalesManager.Availability.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        public virtual string code { get; }

        protected DomainException(string message) : base(message)
        {

        }
    }
}
