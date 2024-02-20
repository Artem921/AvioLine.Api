using Microsoft.AspNetCore.Identity;

namespace AvioLine.Domain.Entities
{
    public class User : IdentityUser
    {
        public const string Admin = "admin";

        public const string AdminPassword = "Aa1.";
 
    }
}
