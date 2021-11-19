using Core.DTOs;

namespace Services
{
    public interface IRegisterUserService
    {
        ValueTask<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto);
    }
}