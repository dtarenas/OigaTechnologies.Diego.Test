using Core.DTOs;
using Core.Entities.User;
using Core.Entities.User.Exceptions;
using DAL.Repositories;

namespace Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IUserRepo _userRepo;

        public RegisterUserService(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        public async ValueTask<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var maybeUser = await this._userRepo.GetByUsernameAsync(registerUserDto.Username);
            if (maybeUser != null) throw new UserAlreadyExistsException(registerUserDto);
            var newUser = await this._userRepo.AddAsync(new User(registerUserDto));
            await this._userRepo.SaveChangesAsync();
            return new UserDto(newUser);
        }
    }
}
