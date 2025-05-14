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
        public string ProfilePictureUrl { get; set; }
    }
    public class UserDetailDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? FavoriteTeam { get; set; }
        public string? Bio { get; set; }
        public bool IsPrivate { get; set; }
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
        public string ProfilePictureUrl { get; set; }
    }
    public class UpdateUserProfileDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FavoriteTeam { get; set; }
        public bool? IsPrivate { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
    }
    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
    public class MeDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FavoriteTeam { get; set; }
        public bool IsPrivate { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
    }

}
