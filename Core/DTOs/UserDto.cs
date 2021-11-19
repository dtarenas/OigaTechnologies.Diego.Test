using Core.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class UserDto : RegisterUserDto
    {
        public UserDto(User user) : base(user)
        {
            this.UserId = user.Id;
        }

        public Guid UserId { get; set; }

    }
}
