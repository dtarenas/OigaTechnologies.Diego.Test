namespace Core.Entities.User.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User is not found")
        {
        }

        public UserNotFoundException(Guid userId) : base($"User with id: '{userId}' is not found")
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
