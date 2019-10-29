using System;

namespace ProductApi.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type)
        {
            EntityType = type;
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public Type EntityType { get; }
    }
}
