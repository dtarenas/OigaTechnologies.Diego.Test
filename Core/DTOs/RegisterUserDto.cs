using Core.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegisterUserDto
    {
        [JsonConstructor]
        public RegisterUserDto()
        {
        }

        public RegisterUserDto(User user)
        {
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            this.Username = user.Username;
        }

        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        public string Fullname => $"{this.Firstname} {this.Lastname}";

        public string FullnameWithUsername => $"{this.Firstname} {this.Lastname} - {this.Username}";
    }
}
