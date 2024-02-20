using AvioLine.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvioLine.Dal
{
    public class IdentityContext : IdentityDbContext<User, Role, string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            Database.Migrate();

        }
    }
}
