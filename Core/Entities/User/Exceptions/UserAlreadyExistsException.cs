using Core.DTOs;

namespace Core.Entities.User.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(UserDto userDto) : base($"User with {nameof(userDto.UserId)}: '{userDto.UserId}' is already exists")
        {
        }

        public UserAlreadyExistsException(RegisterUserDto registerUserDto) : base($"User with {nameof(registerUserDto.Username)}: '{registerUserDto.Username}' is already exists")
        {
        }

        public UserAlreadyExistsException() : base("User is already exists")
        {
        }

        public UserAlreadyExistsException(string? message) : base(message)
        {
        }

        public UserAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
