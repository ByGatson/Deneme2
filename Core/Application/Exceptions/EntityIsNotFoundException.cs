namespace Application.Exceptions
{
    public class EntityIsNotFoundException : Exception
    {
        public EntityIsNotFoundException()
        {
        }

        public EntityIsNotFoundException(string? message) : base(message)
        {
        }
    }
}
