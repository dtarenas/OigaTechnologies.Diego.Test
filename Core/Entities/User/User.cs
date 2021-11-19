using Core.DTOs;
using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.User
{
    [Table("users")]
    public class User : BaseEntity
    {
        public User(string firstname, string lastname, string username)
        {
            this.Username = username;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Fullname = $"{firstname} {lastname}";
        }

        public User(UserDto userDto)
        {
            this.Firstname = userDto.Firstname;
            this.Lastname = userDto.Lastname;
            this.Username = userDto.Username;
            this.Fullname = userDto.Fullname;
            this.Id = userDto.UserId;
        }

        public User(RegisterUserDto registerUserDto)
        {
            this.Firstname = registerUserDto.Firstname;
            this.Lastname = registerUserDto.Lastname;
            this.Username = registerUserDto.Username;
            this.Fullname = registerUserDto.Fullname;
        }

        [Required]
        [StringLength(100)]
        [Column(Order = 1)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(100)]
        [Column(Order = 2)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50)]
        [Column(Order = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [Column(Order = 4)]
        public string Fullname { get; set; }
    }
}