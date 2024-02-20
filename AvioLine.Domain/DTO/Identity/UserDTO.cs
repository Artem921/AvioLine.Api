using AvioLine.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AvioLine.Domain.DTO.Identity
{
    public abstract class UserDTO
    {
        public User User { get; set; }
    }

    public class AddLoginDTO : UserDTO
    {
        public UserLoginInfo LoginInfo { get; set; }
    }

    public class PasswordHashDTO : UserDTO
    {
        public string Hash { get; set; }
    }
}
