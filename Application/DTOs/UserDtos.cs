using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
