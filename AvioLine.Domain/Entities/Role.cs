using Microsoft.AspNetCore.Identity;

namespace AvioLine.Domain.Entities
{
    public class Role : IdentityRole
    {
        public const string Admin = "Admin";

        public const string User = "User";
    }
}
